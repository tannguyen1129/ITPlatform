using AutoMapper;
using BusinessObjects;
using ITPlatformUMT.DTOs.Submittions;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace ITPlatformUMT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmittionsController : ControllerBase
    {
        private readonly ISubmittionService _service;
        private readonly IMapper _mapper;

        public SubmittionsController(ISubmittionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var data = await _service.GetByIdAsync(id);
            return data == null ? NotFound() : Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SubmittionCreateDTO dto)
        {
            var submittion = _mapper.Map<Submittion>(dto);
            submittion.SubmittionID = Guid.NewGuid().ToString();
            await _service.CreateAsync(submittion);
            return Ok(new { message = "Submittion created successfully." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] SubmittionUpdateDTO dto)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(dto, existing);
            await _service.UpdateAsync(existing);
            return Ok(new { message = "Submittion updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _service.DeleteAsync(id);
            return Ok(new { message = "Submittion deleted successfully." });
        }
    }
}