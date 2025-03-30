using AutoMapper;
using BusinessObjects;
using ITPlatformUMT.DTOs.Subscriptions;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace ITPlatformUMT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptionService _service;
        private readonly IMapper _mapper;

        public SubscriptionsController(ISubscriptionService service, IMapper mapper)
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
        public async Task<IActionResult> GetById(string id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubscriptionCreateDTO dto)
        {
            var entity = _mapper.Map<Subscription>(dto);
            await _service.CreateAsync(entity);
            return Ok(entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, SubscriptionUpdateDTO dto)
        {
            if (id != dto.SubscriptionID) return BadRequest("ID mismatch");
            var entity = _mapper.Map<Subscription>(dto);
            await _service.UpdateAsync(entity);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
