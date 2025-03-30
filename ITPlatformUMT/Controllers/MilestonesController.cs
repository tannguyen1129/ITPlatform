using AutoMapper;
using BusinessObjects;
using ITPlatformUMT.DTOs.Milestones;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace ITPlatformUMT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MilestonesController : ControllerBase
    {
        private readonly IMilestoneService _service;
        private readonly IMapper _mapper;

        public MilestonesController(IMilestoneService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var milestone = await _service.GetByIdAsync(id);
            return milestone == null ? NotFound() : Ok(milestone);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MilestoneCreateDTO dto)
        {
            var milestone = _mapper.Map<Milestone>(dto);
            milestone.MilestoneID = Guid.NewGuid().ToString();
            await _service.CreateAsync(milestone);
            return Ok(new { message = "Milestone created successfully." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] MilestoneUpdateDTO dto)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(dto, existing);
            await _service.UpdateAsync(existing);
            return Ok(new { message = "Milestone updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _service.DeleteAsync(id);
            return Ok(new { message = "Milestone deleted successfully." });
        }
    }
}
