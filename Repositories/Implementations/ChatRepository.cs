using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Implementations
{
    public class ChatRepository : IChatRepository
    {
        private readonly MyDbContext _context;

        public ChatRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Chat>> GetAllAsync()
        {
            return await _context.Set<Chat>().ToListAsync();
        }

        public async Task<Chat?> GetByIdAsync(Guid id)
        {
            return await _context.Set<Chat>()
                .Include(c => c.Messages)
                .FirstOrDefaultAsync(c => c.ChatID == id);
        }

        public async Task<Chat?> GetByParticipantsAsync(Guid clientID, Guid freelancerID)
        {
            return await _context.Set<Chat>()
                .FirstOrDefaultAsync(c => c.ClientID == clientID && c.FreelancerID == freelancerID);
        }

        public async Task InsertAsync(Chat chat)
        {
            _context.Set<Chat>().Add(chat);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Chat chat)
        {
            _context.Entry(chat).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var chat = await GetByIdAsync(id);
            if (chat != null)
            {
                _context.Set<Chat>().Remove(chat);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Chat?> GetByClientAndFreelancerAsync(Guid clientID, Guid freelancerID)
{
    return await _context.Set<Chat>()
        .FirstOrDefaultAsync(c => c.ClientID == clientID && c.FreelancerID == freelancerID);
}

    }
}
