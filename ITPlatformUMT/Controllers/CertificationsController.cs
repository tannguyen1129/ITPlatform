using AutoMapper;
using BusinessObjects;
using ITPlatformUMT.DTOs.Certifications;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace ITPlatformUMT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificationsController : ControllerBase
    {
        private readonly ICertificationService _service;
        private readonly IMapper _mapper;

        public CertificationsController(ICertificationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var cert = await _service.GetByIdAsync(id);
            if (cert == null) return NotFound();
            return Ok(cert);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CertificationCreateDTO dto)
        {
            var cert = _mapper.Map<Certification>(dto);
            cert.CertID = Guid.NewGuid().ToString();
            await _service.CreateAsync(cert);
            return Ok(new { message = "Certification created successfully." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] CertificationUpdateDTO dto)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(dto, existing);
            await _service.UpdateAsync(existing);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var cert = await _service.GetByIdAsync(id);
            if (cert == null) return NotFound();

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
