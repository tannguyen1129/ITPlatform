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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _service.GetAllAsync();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var project = await _service.GetByIdAsync(id);
            if (project == null) return NotFound();
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProjectCreateDTO dto)
        {
            var existingClient = await _clientService.GetClientByIdAsync(dto.ClientID);
            if (existingClient == null)
                return BadRequest("ClientID không tồn tại.");

            var project = _mapper.Map<Project>(dto);
            project.ProjectID = Guid.NewGuid().ToString();

            await _service.CreateAsync(project);
            return Ok(new { message = "Project created successfully." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] ProjectUpdateDTO dto)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(dto, existing);
            await _service.UpdateAsync(existing);
            return Ok(new { message = "Project updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _service.DeleteAsync(id);
            return Ok(new { message = "Project deleted successfully." });
        }
    }
}
