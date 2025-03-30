using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class CertificationRepository : ICertificationRepository
    {
        private readonly MyDbContext _context;

        public CertificationRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Certification>> GetAllAsync()
        {
            return await _context.Certifications.ToListAsync();
        }

        public async Task<Certification?> GetByIdAsync(string id)
        {
            return await _context.Certifications.FindAsync(id);
        }

        public async Task CreateAsync(Certification cert)
        {
            await _context.Certifications.AddAsync(cert);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Certification cert)
        {
            _context.Certifications.Update(cert);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var cert = await GetByIdAsync(id);
            if (cert != null)
            {
                _context.Certifications.Remove(cert);
                await _context.SaveChangesAsync();
            }
        }
    }
}
