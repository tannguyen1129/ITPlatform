using Microsoft.AspNetCore.Mvc;
using BusinessObjects;
using Services.Interfaces;
using ITPlatformUMT.DTOs.Messages;
using AutoMapper;

namespace ITPlatformUMT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessagesController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpGet("chat/{chatId}")]
        public async Task<IActionResult> GetByChat(Guid chatId)
        {
            var messages = await _messageService.GetMessagesByChatIdAsync(chatId);
            var result = _mapper.Map<List<MessageResponseDTO>>(messages);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MessageCreateDTO dto)
        {
            var message = _mapper.Map<Message>(dto);
            await _messageService.CreateMessageAsync(message);
            return Ok(_mapper.Map<MessageResponseDTO>(message));
        }
    }
}
