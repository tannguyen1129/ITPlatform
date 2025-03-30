using AutoMapper;
using BusinessObjects;
using ITPlatformUMT.DTOs.Skills;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace ITPlatformUMT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _service;
        private readonly IMapper _mapper;

        public SkillsController(ISkillService service, IMapper mapper)
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
            var skill = await _service.GetByIdAsync(id);
            return skill == null ? NotFound() : Ok(skill);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SkillCreateDTO dto)
        {
            var skill = _mapper.Map<Skill>(dto);
            skill.SkillID = Guid.NewGuid().ToString();
            await _service.CreateAsync(skill);
            return Ok(new { message = "Skill created successfully." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] SkillUpdateDTO dto)
        {
            if (id != dto.SkillID) return BadRequest("ID mismatch.");
            var skill = _mapper.Map<Skill>(dto);
            await _service.UpdateAsync(skill);
            return Ok(new { message = "Skill updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            return Ok(new { message = "Skill deleted successfully." });
        }
    }
}