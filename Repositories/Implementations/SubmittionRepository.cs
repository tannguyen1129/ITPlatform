using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class SubmittionRepository : ISubmittionRepository
    {
        private readonly MyDbContext _context;

        public SubmittionRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Submittion>> GetAllAsync() => await _context.Submittions.ToListAsync();

        public async Task<Submittion?> GetByIdAsync(string id) => await _context.Submittions.FindAsync(id);

        public async Task InsertAsync(Submittion submittion)
        {
            await _context.Submittions.AddAsync(submittion);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Submittion submittion)
        {
            _context.Submittions.Update(submittion);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var sub = await _context.Submittions.FindAsync(id);
            if (sub != null)
            {
                _context.Submittions.Remove(sub);
                await _context.SaveChangesAsync();
            }
        }
    }
}