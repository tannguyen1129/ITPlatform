using AutoMapper;
using BusinessObjects;
using ITPlatformUMT.DTOs.SkillRequirements;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace ITPlatformUMT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillRequirementsController : ControllerBase
    {
        private readonly ISkillRequirementService _service;
        private readonly IMapper _mapper;

        public SkillRequirementsController(ISkillRequirementService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SkillRequirementCreateDTO dto)
        {
            var model = _mapper.Map<SkillRequirement>(dto);
            await _service.CreateAsync(model);
            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, SkillRequirementUpdateDTO dto)
        {
            if (id != dto.SkillRequirementID) return BadRequest("ID mismatch");

            var model = _mapper.Map<SkillRequirement>(dto);
            await _service.UpdateAsync(model);
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
