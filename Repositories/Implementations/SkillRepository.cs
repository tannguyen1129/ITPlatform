using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class SkillRepository : ISkillRepository
    {
        private readonly MyDbContext _context;

        public SkillRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Skill>> GetAllAsync() => await _context.Skills.ToListAsync();

        public async Task<Skill?> GetByIdAsync(string id) => await _context.Skills.FindAsync(id);

        public async Task InsertAsync(Skill skill)
        {
            await _context.Skills.AddAsync(skill);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Skill skill)
        {
            _context.Skills.Update(skill);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var skill = await GetByIdAsync(id);
            if (skill != null)
            {
                _context.Skills.Remove(skill);
                await _context.SaveChangesAsync();
            }
        }
    }
}
