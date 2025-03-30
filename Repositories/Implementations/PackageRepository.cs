using BusinessObjects;
using DataAccessObjects;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class PackageRepository : IPackageRepository
    {
        private readonly MyDbContext _context;

        public PackageRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Package>> GetAllAsync()
        {
            return await _context.Packages.ToListAsync();
        }

        public async Task<Package?> GetByIdAsync(string id)
        {
            return await _context.Packages.FindAsync(id);
        }

        public async Task InsertAsync(Package package)
        {
            package.PackageID = Guid.NewGuid().ToString();
            _context.Packages.Add(package);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Package package)
        {
            _context.Packages.Update(package);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var pkg = await _context.Packages.FindAsync(id);
            if (pkg != null)
            {
                _context.Packages.Remove(pkg);
                await _context.SaveChangesAsync();
            }
        }
    }
}
