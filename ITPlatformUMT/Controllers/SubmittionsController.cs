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

        // ========================================
        // GET: All & ByID
        // ========================================
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var data = await _service.GetByIdAsync(id);
            return data == null ? NotFound("Không tìm thấy bài nộp.") : Ok(data);
        }

        // ========================================
        // POST: Create mới (JSON)
        // ========================================
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SubmittionCreateDTO dto)
        {
            if (string.IsNullOrEmpty(dto.FreelancerID))
                return BadRequest("FreelancerID là bắt buộc.");

            var submittion = _mapper.Map<Submittion>(dto);
            submittion.SubmittionID = Guid.NewGuid().ToString();
            submittion.CreatedAt = DateTime.UtcNow;
            submittion.Status = "Pending";

            await _service.CreateAsync(submittion);
            return Ok(submittion);
        }

        // ========================================
        // POST: Tạo bài nộp có file
        // ========================================
        [HttpPost("upload")]
        public async Task<IActionResult> CreateWithFile([FromForm] SubmittionCreateWithFileDTO dto)
        {
            if (string.IsNullOrEmpty(dto.FreelancerID))
                return BadRequest("FreelancerID là bắt buộc.");

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

            var submittion = new Submittion
            {
                SubmittionID = Guid.NewGuid().ToString(),
                MilestoneID = dto.MilestoneID,
                FreelancerID = dto.FreelancerID,
                Description = dto.Description,
                FilePath = fileName,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow
            };

            await _service.CreateAsync(submittion);
            return Ok(submittion);
        }

        // ========================================
        // PUT: Cập nhật toàn bộ bài nộp (từ JSON)
        // ========================================
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] SubmittionUpdateDTO dto)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null)
                return NotFound("Không tìm thấy bài nộp.");

            _mapper.Map(dto, existing);
            existing.UpdatedAt = DateTime.UtcNow;

            await _service.UpdateAsync(existing);
            return Ok(existing);
        }

        // ========================================
        // PUT: Cập nhật bài nộp có file đính kèm
        // ========================================
        [HttpPut("upload/{id}")]
        public async Task<IActionResult> UpdateWithFile(string id, [FromForm] SubmittionCreateWithFileDTO dto)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound("Không tìm thấy bài nộp.");

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

            existing.Description = dto.Description;
            existing.UpdatedAt = DateTime.UtcNow;
            existing.Status = "Updated";

            await _service.UpdateAsync(existing);
            return Ok(existing);
        }

        // ========================================
        // PUT: Cập nhật trạng thái riêng biệt
        // ========================================
        [HttpPut("status/{id}")]
        public async Task<IActionResult> UpdateStatus(string id, [FromBody] SubmittionStatusUpdateDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Status))
                return BadRequest("Trạng thái không được để trống.");

            var allowedStatuses = new[] { "Pending", "Approved", "Rejected", "Updated", "Completed" };
            if (!allowedStatuses.Contains(dto.Status))
                return BadRequest($"Trạng thái không hợp lệ. Hợp lệ: {string.Join(", ", allowedStatuses)}");

            var existing = await _service.GetByIdAsync(id);
            if (existing == null)
                return NotFound("Không tìm thấy bài nộp.");

            existing.Status = dto.Status;
            existing.UpdatedAt = DateTime.UtcNow;

            await _service.UpdateAsync(existing);
            return Ok(new
            {
                message = $"Đã cập nhật trạng thái bài nộp thành '{dto.Status}'.",
                updated = existing
            });
        }

        // ========================================
        // DELETE: Xoá bài nộp
        // ========================================
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound("Không tìm thấy bài nộp.");

            await _service.DeleteAsync(id);
            return Ok(new { message = "Đã xoá bài nộp thành công." });
        }
    }
}
