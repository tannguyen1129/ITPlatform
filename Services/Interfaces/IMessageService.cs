using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessObjects;

namespace Services.Interfaces
{
    public interface IMessageService
    {
        Task<List<Message>> GetAllMessagesAsync();
        Task<Message?> GetMessageByIdAsync(Guid messageId);
        Task<List<Message>> GetMessagesByChatIdAsync(Guid chatId);
        Task CreateMessageAsync(Message message);
        Task UpdateMessageAsync(Message message);
        Task DeleteMessageAsync(Guid messageId);
    }
}
