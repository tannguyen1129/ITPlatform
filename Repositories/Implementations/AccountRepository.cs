using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MyDbContext _context;

        public AccountRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Account>> GetAllAsync()
            => await _context.Accounts.ToListAsync();

        public async Task<Account?> GetByIdAsync(string id)
            => await _context.Accounts.FindAsync(id);

        public async Task<Account?> GetByEmailAsync(string email)
            => await _context.Accounts.FirstOrDefaultAsync(a => a.Email == email);

        public async Task InsertAsync(Account account)
        {
            account.AccountID = Guid.NewGuid().ToString();
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var account = await GetByIdAsync(id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
            }
        }
    }
}
