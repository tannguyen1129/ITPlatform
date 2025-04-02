using AutoMapper;
using BusinessObjects;
using ITPlatformUMT.DTOs.Submittions;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace ITPlatformUMT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmittionsController : ControllerBase
    {
        private readonly ISubmittionService _service;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public SubmittionsController(ISubmittionService service, IMapper mapper, IWebHostEnvironment env)
        {
            _service = service;
            _mapper = mapper;
            _env = env;
        }

        // GET: api/submittions
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        // GET: api/submittions/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var data = await _service.GetByIdAsync(id);
            return data == null ? NotFound() : Ok(data);
        }

        // POST: api/submittions
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SubmittionCreateDTO dto)
        {
            var submittion = _mapper.Map<Submittion>(dto);
            submittion.SubmittionID = Guid.NewGuid().ToString();
            submittion.CreatedAt = DateTime.UtcNow;
            submittion.Status = "Pending";

            // ⚠️ Đảm bảo đã gán FreelancerID
            if (string.IsNullOrEmpty(submittion.FreelancerID))
                return BadRequest("FreelancerID is required.");

            await _service.CreateAsync(submittion);
            return Ok(submittion);
        }

        // POST: api/submittions/upload
        [HttpPost("upload")]
        public async Task<IActionResult> CreateWithFile([FromForm] SubmittionCreateWithFileDTO dto)
        {
            var fileName = "";
            if (dto.File != null)
            {
                var folder = Path.Combine(_env.WebRootPath ?? "wwwroot", "submittions");
                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
                fileName = $"{Guid.NewGuid()}_{dto.File.FileName}";
                var path = Path.Combine(folder, fileName);
                using var stream = new FileStream(path, FileMode.Create);
                await dto.File.CopyToAsync(stream);
            }

            // ✅ Fix: gán FreelancerID để tránh lỗi CS9035
            var submittion = new Submittion
            {
                SubmittionID = Guid.NewGuid().ToString(),
                MilestoneID = dto.MilestoneID,
                FreelancerID = dto.FreelancerID, // ✅ BẮT BUỘC
                Description = dto.Description,
                FilePath = fileName,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow
            };

            await _service.CreateAsync(submittion);
            return Ok(submittion);
        }

        // PUT: api/submittions/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] SubmittionUpdateDTO dto)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(dto, existing);
            await _service.UpdateAsync(existing);
            return Ok(existing);
        }

        // PUT: api/submittions/status/{id}
        // PUT: api/submittions/upload/{id}
[HttpPut("upload/{id}")]
public async Task<IActionResult> UpdateWithFile(string id, [FromForm] SubmittionCreateWithFileDTO dto)
{
    var existing = await _service.GetByIdAsync(id);
    if (existing == null) return NotFound();

    // Nếu có file mới thì lưu lại file mới
    if (dto.File != null)
    {
        var folder = Path.Combine(_env.WebRootPath ?? "wwwroot", "submittions");
        if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

        var fileName = $"{Guid.NewGuid()}_{dto.File.FileName}";
        var path = Path.Combine(folder, fileName);

        using var stream = new FileStream(path, FileMode.Create);
        await dto.File.CopyToAsync(stream);

        existing.FilePath = fileName;
    }

    // Cập nhật các thông tin khác
    existing.Description = dto.Description;
    existing.UpdatedAt = DateTime.UtcNow;
    existing.Status = "Updated";

    await _service.UpdateAsync(existing);
    return Ok(existing);
}


        // DELETE: api/submittions/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _service.DeleteAsync(id);
            return Ok(new { message = "Submittion deleted successfully." });
        }
    }
}
