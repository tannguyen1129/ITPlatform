using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class MilestoneRepository : IMilestoneRepository
    {
        private readonly MyDbContext _context;

        public MilestoneRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Milestone>> GetAllAsync() => await _context.Milestones.ToListAsync();

        public async Task<Milestone?> GetByIdAsync(string id) => await _context.Milestones.FindAsync(id);

        public async Task InsertAsync(Milestone milestone)
        {
            await _context.Milestones.AddAsync(milestone);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Milestone milestone)
        {
            _context.Milestones.Update(milestone);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var milestone = await _context.Milestones.FindAsync(id);
            if (milestone != null)
            {
                _context.Milestones.Remove(milestone);
                await _context.SaveChangesAsync();
            }
        }
    }
}