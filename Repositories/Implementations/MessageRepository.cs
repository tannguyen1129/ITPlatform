using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Implementations
{
    public class MessageRepository : IMessageRepository
    {
        private readonly MyDbContext _context;

        public MessageRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Message>> GetAllAsync() =>
            await _context.Set<Message>().ToListAsync();

        public async Task<Message?> GetByIdAsync(Guid id) =>
            await _context.Set<Message>().FirstOrDefaultAsync(m => m.MessageID == id);

        public async Task<List<Message>> GetByChatIdAsync(Guid chatId) =>
            await _context.Set<Message>().Where(m => m.ChatID == chatId).ToListAsync();

        public async Task InsertAsync(Message message)
        {
            _context.Set<Message>().Add(message);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Message message)
        {
            _context.Set<Message>().Update(message);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var msg = await GetByIdAsync(id);
            if (msg != null)
            {
                _context.Set<Message>().Remove(msg);
                await _context.SaveChangesAsync();
            }
        }
    }
}
