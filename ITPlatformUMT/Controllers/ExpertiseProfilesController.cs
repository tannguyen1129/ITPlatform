using AutoMapper;
using BusinessObjects;
using ITPlatformUMT.DTOs.ExpertiseProfiles;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace ITPlatformUMT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpertiseProfilesController : ControllerBase
    {
        private readonly IExpertiseProfileService _service;
        private readonly IMapper _mapper;

        public ExpertiseProfilesController(IExpertiseProfileService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var data = await _service.GetByIdAsync(id);
            return data == null ? NotFound() : Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ExpertiseProfileCreateDTO dto)
        {
            var entity = _mapper.Map<ExpertiseProfile>(dto);
            await _service.CreateAsync(entity);
            return Ok(new { message = "Created successfully." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] ExpertiseProfileUpdateDTO dto)
        {
            if (id != dto.ProfileID) return BadRequest("ID mismatch.");

            var entity = _mapper.Map<ExpertiseProfile>(dto);
            await _service.UpdateAsync(entity);
            return Ok(new { message = "Updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            return Ok(new { message = "Deleted successfully." });
        }
    }
}
