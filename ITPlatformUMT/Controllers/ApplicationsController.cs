using AutoMapper;
using BusinessObjects;
using ITPlatformUMT.DTOs.Applications;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace ITPlatformUMT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationService _service;
        private readonly IProjectService _projectService;
        private readonly IFreelancerService _freelancerService;
        private readonly IMapper _mapper;

        public ApplicationsController(
            IApplicationService service,
            IProjectService projectService,
            IFreelancerService freelancerService,
            IMapper mapper)
        {
            _service = service;
            _projectService = projectService;
            _freelancerService = freelancerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var apps = await _service.GetAllAsync();

            foreach (var app in apps)
            {
                var project = await _projectService.GetByIdAsync(app.ProjectID);
                var freelancer = await _freelancerService.GetByIdAsync(app.FreelancerID);

                if (project == null || freelancer == null)
                    continue; // hoặc return BadRequest("Invalid project or freelancer.");

                app.Project = project;
                app.Freelancer = freelancer;
            }

            return Ok(apps);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var app = await _service.GetByIdAsync(id);
            if (app == null) return NotFound();

            var project = await _projectService.GetByIdAsync(app.ProjectID);
            var freelancer = await _freelancerService.GetByIdAsync(app.FreelancerID);

            if (project == null || freelancer == null)
                return BadRequest("Project hoặc Freelancer không tồn tại.");

            app.Project = project;
            app.Freelancer = freelancer;

            return Ok(app);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApplicationCreateDTO dto)
        {
            var app = _mapper.Map<Application>(dto);
            await _service.CreateAsync(app);

            var project = await _projectService.GetByIdAsync(app.ProjectID);
            var freelancer = await _freelancerService.GetByIdAsync(app.FreelancerID);

            if (project == null || freelancer == null)
                return BadRequest("Project hoặc Freelancer không tồn tại.");

            app.Project = project;
            app.Freelancer = freelancer;

            return Ok(app);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, ApplicationUpdateDTO dto)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(dto, existing);
            await _service.UpdateAsync(existing);

            var project = await _projectService.GetByIdAsync(existing.ProjectID);
            var freelancer = await _freelancerService.GetByIdAsync(existing.FreelancerID);

            if (project == null || freelancer == null)
                return BadRequest("Project hoặc Freelancer không tồn tại.");

            existing.Project = project;
            existing.Freelancer = freelancer;

            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
