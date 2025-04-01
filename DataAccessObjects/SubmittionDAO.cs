using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class SubmittionDAO
    {
        private readonly MyDbContext _context;

        public SubmittionDAO(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Submittion>> GetAllAsync()
        {
            return await _context.Submittions
                .Include(s => s.Milestone)
                .Include(s => s.Freelancer)
                .ToListAsync();
        }

        public async Task<Submittion?> GetByIdAsync(string id)
        {
            return await _context.Submittions
                .Include(s => s.Milestone)
                .Include(s => s.Freelancer)
                .FirstOrDefaultAsync(s => s.SubmittionID == id);
        }

        public async Task CreateAsync(Submittion submittion)
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
            var submittion = await _context.Submittions.FindAsync(id);
            if (submittion != null)
            {
                _context.Submittions.Remove(submittion);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Submittion>> GetByMilestoneIdAsync(string milestoneId)
        {
            return await _context.Submittions
                .Where(s => s.MilestoneID == milestoneId)
                .Include(s => s.Freelancer)
                .ToListAsync();
        }
    }
}
