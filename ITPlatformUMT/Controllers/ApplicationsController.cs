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
        private readonly IWebHostEnvironment _env;

        public ApplicationsController(
            IApplicationService service,
            IProjectService projectService,
            IFreelancerService freelancerService,
            IMapper mapper,
            IWebHostEnvironment env)
        {
            _service = service;
            _projectService = projectService;
            _freelancerService = freelancerService;
            _mapper = mapper;
            _env = env;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var apps = await _service.GetAllAsync();

            foreach (var app in apps)
            {
                var project = await _projectService.GetByIdAsync(app.ProjectID);
                var freelancer = await _freelancerService.GetByIdAsync(app.FreelancerID);

                if (project != null && freelancer != null)
                {
                    app.Project = project;
                    app.Freelancer = freelancer;
                }
            }

            return Ok(apps);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var app = await _service.GetByIdAsync(id);
            if (app == null) return NotFound();

            var project = await _projectService.GetByIdAsync(app.ProjectID);
            if (project == null) return BadRequest("Project không tồn tại.");

            var freelancer = await _freelancerService.GetByIdAsync(app.FreelancerID);
            if (freelancer == null) return BadRequest("Freelancer không tồn tại.");

            app.Project = project;
            app.Freelancer = freelancer;

            return Ok(app);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ApplicationCreateDTO dto)
        {
            var app = _mapper.Map<Application>(dto);

            if (dto.CVFile != null && dto.CVFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(_env.WebRootPath, "cv-uploads");
                if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(dto.CVFile.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.CVFile.CopyToAsync(stream);
                }

                app.CV = fileName;
            }

            await _service.CreateAsync(app);

            var project = await _projectService.GetByIdAsync(app.ProjectID);
            if (project == null) return BadRequest("Project không tồn tại.");

            var freelancer = await _freelancerService.GetByIdAsync(app.FreelancerID);
            if (freelancer == null) return BadRequest("Freelancer không tồn tại.");

            app.Project = project;
            app.Freelancer = freelancer;

            return Ok(app);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromForm] ApplicationUpdateDTO dto)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.Status = dto.Status ?? existing.Status;
            existing.FreelancerID = dto.FreelancerID ?? existing.FreelancerID;
            existing.ProjectID = dto.ProjectID ?? existing.ProjectID;

            if (dto.CVFile != null && dto.CVFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(_env.WebRootPath, "cv-uploads");
                if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(dto.CVFile.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.CVFile.CopyToAsync(stream);
                }

                existing.CV = fileName;
            }

            var project = await _projectService.GetByIdAsync(existing.ProjectID);
            if (project == null) return BadRequest("Project không tồn tại.");

            var freelancer = await _freelancerService.GetByIdAsync(existing.FreelancerID);
            if (freelancer == null) return BadRequest("Freelancer không tồn tại.");

            existing.Project = project;
            existing.Freelancer = freelancer;

            await _service.UpdateAsync(existing);
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
