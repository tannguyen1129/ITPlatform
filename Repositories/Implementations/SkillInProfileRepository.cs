// SkillInProfileRepository.cs
using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class SkillInProfileRepository : ISkillInProfileRepository
    {
        private readonly MyDbContext _context;
        public SkillInProfileRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<SkillInProfile>> GetAllAsync() =>
            await _context.SkillInProfiles.Include(s => s.Skill).Include(p => p.ExpertiseProfile).ToListAsync();

        public async Task<SkillInProfile?> GetByIdAsync(string id) =>
            await _context.SkillInProfiles.FirstOrDefaultAsync(x => x.SkillInProfileID == id);

        public async Task InsertAsync(SkillInProfile entity)
        {
            entity.SkillInProfileID = Guid.NewGuid().ToString();
            _context.SkillInProfiles.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SkillInProfile entity)
        {
            _context.SkillInProfiles.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var item = await GetByIdAsync(id);
            if (item != null)
            {
                _context.SkillInProfiles.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
