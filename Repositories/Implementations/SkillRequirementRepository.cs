using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class SkillRequirementRepository : ISkillRequirementRepository
    {
        private readonly MyDbContext _context;

        public SkillRequirementRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<SkillRequirement>> GetAllAsync()
        {
            return await _context.SkillRequirements.Include(s => s.Skill).Include(p => p.Project).ToListAsync();
        }

        public async Task<SkillRequirement?> GetByIdAsync(string id)
        {
            return await _context.SkillRequirements.FindAsync(id);
        }

        public async Task InsertAsync(SkillRequirement skillRequirement)
        {
            skillRequirement.SkillRequirementID = Guid.NewGuid().ToString();
            _context.SkillRequirements.Add(skillRequirement);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SkillRequirement skillRequirement)
        {
            _context.SkillRequirements.Update(skillRequirement);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var skillRequirement = await GetByIdAsync(id);
            if (skillRequirement != null)
            {
                _context.SkillRequirements.Remove(skillRequirement);
                await _context.SaveChangesAsync();
            }
        }
    }
}
