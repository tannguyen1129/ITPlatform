using Microsoft.AspNetCore.Mvc;
using BusinessObjects;
using ITPlatformUMT.DTOs.Clients;
using Services.Interfaces;
using AutoMapper;

namespace ITPlatformUMT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public ClientsController(
            IClientService clientService,
            IAccountService accountService,
            IMapper mapper)
        {
            _clientService = clientService;
            _accountService = accountService;
            _mapper = mapper;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var clients = await _clientService.GetAllClientsAsync();
            return Ok(clients);
        }

        // GET: api/Clients/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(string id)
        {
            var client = await _clientService.GetClientByIdAsync(id);
            if (client == null)
                return NotFound();

            return Ok(client);
        }

        // POST: api/Clients
        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] ClientCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _accountService.GetByIdAsync(dto.AccountID); // đã sửa tên hàm
            if (existing == null)
                return BadRequest("AccountID không tồn tại!");

            var client = _mapper.Map<Client>(dto);
            client.ClientID = Guid.NewGuid().ToString();
            client.LocationList = new();
            client.ProjectList = new();
            client.SubscriptionList = new();

            await _clientService.CreateClientAsync(client);
            return Ok(new { message = "Client created successfully." });
        }

        // PUT: api/Clients/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(string id, [FromBody] ClientUpdateDTO dto)
        {
            var existing = await _clientService.GetClientByIdAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(dto, existing); // Map field mới vào object cũ đã tracked
            await _clientService.UpdateClientAsync(existing);
            return NoContent();
        }

        // DELETE: api/Clients/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(string id)
        {
            var exists = await _clientService.GetClientByIdAsync(id);
            if (exists == null)
                return NotFound();

            await _clientService.DeleteClientAsync(id);
            return NoContent();
        }
    }
}
