using AutoMapper;
using BusinessObjects;
using ITPlatformUMT.DTOs.Locations;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace ITPlatformUMT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _service;
        private readonly IMapper _mapper;

        public LocationsController(ILocationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var locations = await _service.GetAllAsync();
            return Ok(locations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var location = await _service.GetByIdAsync(id);
            if (location == null) return NotFound();
            return Ok(location);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LocationCreateDTO dto)
        {
            var location = _mapper.Map<Location>(dto);
            await _service.CreateAsync(location);
            return Ok(new { message = "Created successfully" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] LocationUpdateDTO dto)
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
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
