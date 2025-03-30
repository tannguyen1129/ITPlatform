using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class LocationRepository : ILocationRepository
    {
        private readonly MyDbContext _context;

        public LocationRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Location>> GetAllAsync() => await _context.Locations.ToListAsync();

        public async Task<Location?> GetByIdAsync(string id) =>
            await _context.Locations.FirstOrDefaultAsync(l => l.LocationID == id);

        public async Task InsertAsync(Location location)
        {
            location.LocationID = Guid.NewGuid().ToString();
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Location location)
        {
            _context.Locations.Update(location);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var loc = await GetByIdAsync(id);
            if (loc != null)
            {
                _context.Locations.Remove(loc);
                await _context.SaveChangesAsync();
            }
        }
    }
}
