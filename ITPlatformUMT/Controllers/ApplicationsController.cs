using AutoMapper;
using BusinessObjects;
using ITPlatformUMT.DTOs.Applications;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Microsoft.AspNetCore.Hosting;

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

                if (project != null) app.Project = project;
                if (freelancer != null) app.Freelancer = freelancer;
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

            if (project != null) app.Project = project;
            if (freelancer != null) app.Freelancer = freelancer;

            return Ok(app);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ApplicationCreateDTO dto)
        {
            var app = _mapper.Map<Application>(dto);

            if (dto.CVFile != null && dto.CVFile.Length > 0)
            {
                var webRootPath = _env.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                var uploadsFolder = Path.Combine(webRootPath, "cv-uploads");
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
            var freelancer = await _freelancerService.GetByIdAsync(app.FreelancerID);

            if (project != null) app.Project = project;
            if (freelancer != null) app.Freelancer = freelancer;

            return Ok(app);
        }

[HttpPut("{id}")]
public async Task<IActionResult> Update(string id, [FromForm] ApplicationUpdateDTO dto)
{
    var existing = await _service.GetByIdAsync(id);
    if (existing == null) return NotFound();

    existing.CoverLetter = dto.CoverLetter ?? existing.CoverLetter;
    existing.Status = dto.Status ?? existing.Status;
    existing.FreelancerID = dto.FreelancerID ?? existing.FreelancerID;
    existing.ProjectID = dto.ProjectID ?? existing.ProjectID;

    // Xử lý file CV mới (nếu có)
    if (dto.CVFile != null && dto.CVFile.Length > 0)
    {
        var webRootPath = _env.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        var uploadsFolder = Path.Combine(webRootPath, "cv-uploads");
        if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(dto.CVFile.FileName);
        var filePath = Path.Combine(uploadsFolder, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await dto.CVFile.CopyToAsync(stream);
        }

        existing.CV = fileName;
    }

    // ✅ Nếu đơn được duyệt -> từ chối tất cả đơn khác cùng dự án
    if (existing.Status?.ToLower() == "accepted")
    {
        var allApplications = await _service.GetAllAsync();
        var relatedApps = allApplications
            .Where(a => a.ProjectID == existing.ProjectID && a.ApplicationID != existing.ApplicationID)
            .ToList();

        foreach (var app in relatedApps)
        {
            if (app.Status?.ToLower() == "pending")
            {
                app.Status = "Rejected";
                await _service.UpdateAsync(app);
            }
        }
    }

    // Cập nhật đơn hiện tại
    await _service.UpdateAsync(existing);

    // Gắn dữ liệu liên quan
    var project = await _projectService.GetByIdAsync(existing.ProjectID);
    var freelancer = await _freelancerService.GetByIdAsync(existing.FreelancerID);

    if (project != null) existing.Project = project;
    if (freelancer != null) existing.Freelancer = freelancer;

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