// SkillInProfilesController.cs
using AutoMapper;
using BusinessObjects;
using ITPlatformUMT.DTOs.SkillInProfiles;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace ITPlatformUMT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillInProfilesController : ControllerBase
    {
        private readonly ISkillInProfileService _service;
        private readonly IMapper _mapper;

        public SkillInProfilesController(ISkillInProfileService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SkillInProfileCreateDTO dto)
        {
            var entity = _mapper.Map<SkillInProfile>(dto);
            await _service.CreateAsync(entity);
            return Ok(entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, SkillInProfileUpdateDTO dto)
        {
            if (id != dto.SkillInProfileID) return BadRequest();
            var entity = _mapper.Map<SkillInProfile>(dto);
            await _service.UpdateAsync(entity);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
