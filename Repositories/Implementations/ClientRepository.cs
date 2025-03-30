using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.Implementations
{
    public class ClientRepository : IClientRepository
    {
        private readonly MyDbContext _context;

        public ClientRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Client>> GetAllAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client?> GetByIdAsync(string clientId)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.ClientID == clientId);
        }

        public async Task<Client?> GetByAccountIdAsync(string accountId)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.AccountID == accountId);
        }

        public async Task<List<Client>> GetByFieldAsync(string field)
        {
            return await _context.Clients
                .Where(c => c.Field == field)
                .ToListAsync();
        }

        public async Task InsertAsync(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Client client)
       {
            await _context.SaveChangesAsync();
       }
        public async Task DeleteAsync(string clientId)
        {
            var client = await GetByIdAsync(clientId);
            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
        }
    }
}
