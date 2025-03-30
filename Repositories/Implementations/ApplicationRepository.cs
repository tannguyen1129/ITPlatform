using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly MyDbContext _context;

        public ApplicationRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Application>> GetAllAsync() =>
            await _context.Applications.ToListAsync();

        public async Task<Application?> GetByIdAsync(string id) =>
            await _context.Applications.FindAsync(id);

        public async Task InsertAsync(Application application)
        {
            application.ApplicationID = Guid.NewGuid().ToString();
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Application application)
        {
            _context.Applications.Update(application);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var app = await _context.Applications.FindAsync(id);
            if (app != null)
            {
                _context.Applications.Remove(app);
                await _context.SaveChangesAsync();
            }
        }
    }
}
