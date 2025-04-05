using Microsoft.AspNetCore.Mvc;
using BusinessObjects;
using Services.Interfaces;
using ITPlatformUMT.DTOs.Chat;
using AutoMapper;

namespace ITPlatformUMT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatsController : ControllerBase
    {
        private readonly IChatService _chatService;
        private readonly IMapper _mapper;

        public ChatsController(IChatService chatService, IMapper mapper)
        {
            _chatService = chatService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var chats = await _chatService.GetAllChatsAsync();
            var result = _mapper.Map<List<ChatResponseDTO>>(chats);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var chat = await _chatService.GetChatByIdAsync(id);
            if (chat == null) return NotFound();
            return Ok(_mapper.Map<ChatResponseDTO>(chat));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ChatCreateDTO dto)
        {
            var existing = await _chatService.GetChatByClientAndFreelancerAsync(dto.ClientID, dto.FreelancerID);
            if (existing != null)
                return Conflict("Chat already exists.");

            var chat = _mapper.Map<Chat>(dto);
            await _chatService.CreateChatAsync(chat);
            return Ok(_mapper.Map<ChatResponseDTO>(chat));
        }
    }
}
