using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessObjects;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<List<Message>> GetAllMessagesAsync()
        {
            return await _messageRepository.GetAllAsync();
        }

        public async Task<Message?> GetMessageByIdAsync(Guid messageId)
        {
            return await _messageRepository.GetByIdAsync(messageId);
        }

        public async Task<List<Message>> GetMessagesByChatIdAsync(Guid chatId)
        {
            return await _messageRepository.GetByChatIdAsync(chatId);
        }

        public async Task CreateMessageAsync(Message message)
        {
            await _messageRepository.InsertAsync(message);
        }

        public async Task UpdateMessageAsync(Message message)
        {
            await _messageRepository.UpdateAsync(message);
        }

        public async Task DeleteMessageAsync(Guid messageId)
        {
            await _messageRepository.DeleteAsync(messageId);
        }
    }
}
