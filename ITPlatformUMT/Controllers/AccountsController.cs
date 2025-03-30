using AutoMapper;
using BusinessObjects;
using ITPlatformUMT.DTOs.Accounts;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace ITPlatformUMT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _service;
        private readonly IMapper _mapper;

        public AccountsController(IAccountService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var accounts = await _service.GetAllAsync();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var account = await _service.GetByIdAsync(id);
            if (account == null) return NotFound();
            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AccountCreateDTO dto)
        {
            var account = _mapper.Map<Account>(dto);
            await _service.CreateAsync(account);
            return CreatedAtAction(nameof(GetById), new { id = account.AccountID }, account);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, AccountUpdateDTO dto)
        {
            if (id != dto.AccountID) return BadRequest("ID mismatch");

            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();

            var updated = _mapper.Map(dto, existing);
            await _service.UpdateAsync(updated);
            return Ok(updated);
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
