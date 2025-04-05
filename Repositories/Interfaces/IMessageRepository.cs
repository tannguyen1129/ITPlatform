using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IMessageRepository
    {
        Task<List<Message>> GetAllAsync();
        Task<Message?> GetByIdAsync(Guid id);
        Task<List<Message>> GetByChatIdAsync(Guid chatId);
        Task InsertAsync(Message message);
        Task UpdateAsync(Message message);
        Task DeleteAsync(Guid id);
    }
}
