using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class ExpertiseProfileRepository : IExpertiseProfileRepository
    {
        private readonly MyDbContext _context;

        public ExpertiseProfileRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<ExpertiseProfile>> GetAllAsync()
        {
            return await _context.ExpertiseProfiles.ToListAsync();
        }

        public async Task<ExpertiseProfile?> GetByIdAsync(string id)
        {
            return await _context.ExpertiseProfiles.FindAsync(id);
        }

        public async Task InsertAsync(ExpertiseProfile profile)
        {
            profile.ProfileID = Guid.NewGuid().ToString();
            _context.ExpertiseProfiles.Add(profile);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ExpertiseProfile profile)
        {
            _context.ExpertiseProfiles.Update(profile);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var profile = await _context.ExpertiseProfiles.FindAsync(id);
            if (profile != null)
            {
                _context.ExpertiseProfiles.Remove(profile);
                await _context.SaveChangesAsync();
            }
        }
    }
}
