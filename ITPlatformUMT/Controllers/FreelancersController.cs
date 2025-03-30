using ITPlatformUMT.DTOs.Freelancers;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using AutoMapper;
using BusinessObjects;

namespace ITPlatformUMT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FreelancerController : ControllerBase
    {
        private readonly IFreelancerService _service;
        private readonly IMapper _mapper;

        public FreelancerController(IFreelancerService service, IMapper mapper)
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
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FreelancerCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var freelancer = _mapper.Map<Freelancer>(dto);
            freelancer.FreelancerID = Guid.NewGuid().ToString();

            await _service.CreateAsync(freelancer);
            return Ok(new { message = "Created successfully." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] FreelancerUpdateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _service.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            _mapper.Map(dto, existing); // map DTO vào entity đang được tracked
            await _service.UpdateAsync(existing);

            return Ok(new { message = "Updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _service.DeleteAsync(id);
            return Ok(new { message = "Deleted successfully." });
        }
    }
}
