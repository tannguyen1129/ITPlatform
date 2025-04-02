using AutoMapper;
using BusinessObjects;
using ITPlatformUMT.DTOs.Projects;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace ITPlatformUMT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _service;
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ProjectsController(IProjectService service, IClientService clientService, IMapper mapper)
        {
            _service = service;
            _clientService = clientService;
            _mapper = mapper;
        }

        // Lấy tất cả dự án
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _service.GetAllAsync();
            return Ok(projects);
        }

        // Lấy dự án theo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var project = await _service.GetByIdAsync(id);
            if (project == null) return NotFound();
            return Ok(project);
        }

        // Tạo mới dự án
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProjectCreateDTO dto)
        {
            var existingClient = await _clientService.GetClientByIdAsync(dto.ClientID);
            if (existingClient == null)
                return BadRequest("ClientID không tồn tại.");

            var project = _mapper.Map<Project>(dto);
            project.ProjectID = Guid.NewGuid().ToString();
            project.IsActive = true; // ✅ Mặc định đang tuyển

            await _service.CreateAsync(project);
            return Ok(new { message = "Project created successfully.", project });
        }

        // Cập nhật dự án
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] ProjectUpdateDTO dto)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(dto, existing);
            await _service.UpdateAsync(existing);
            return Ok(new { message = "Project updated successfully." });
        }

        // Xoá dự án
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _service.DeleteAsync(id);
            return Ok(new { message = "Project deleted successfully." });
        }

        // ✅ Ngừng tuyển Freelancer (ẩn khỏi danh sách Freelancer)
        [HttpPut("deactivate/{id}")]
        public async Task<IActionResult> Deactivate(string id)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound("Không tìm thấy dự án.");

            existing.IsActive = false;
            await _service.UpdateAsync(existing);

            return Ok(new { message = "Dự án đã được ngừng tuyển freelancer." });
        }

        // ✅ Danh sách các project đang mở để freelancer xem
        [HttpGet("active")]
        public async Task<IActionResult> GetActiveProjects()
        {
            var all = await _service.GetAllAsync();
            var activeProjects = all.Where(p => p.IsActive && p.Status == "Open").ToList();
            return Ok(activeProjects);
        }
    }
}
