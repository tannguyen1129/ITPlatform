using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class FreelancerRepository : IFreelancerRepository
    {
        private readonly MyDbContext _context;

        public FreelancerRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Freelancer>> GetAllAsync()
        {
            return await _context.Set<Freelancer>().ToListAsync();
        }

        public async Task<Freelancer?> GetByIdAsync(string id)
        {
            return await _context.Set<Freelancer>().FindAsync(id);
        }

        public async Task AddAsync(Freelancer freelancer)
        {
            await _context.Set<Freelancer>().AddAsync(freelancer);
            await _context.SaveChangesAsync();
        }

        public async Task InsertAsync(Freelancer freelancer)
        {
            await _context.Set<Freelancer>().AddAsync(freelancer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Freelancer freelancer)
        {
            _context.Set<Freelancer>().Update(freelancer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var freelancer = await GetByIdAsync(id);
            if (freelancer != null)
            {
                _context.Set<Freelancer>().Remove(freelancer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
