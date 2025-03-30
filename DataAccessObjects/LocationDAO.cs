using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class LocationDAO
    {
        private readonly MyDbContext _context;

        public LocationDAO(MyDbContext context)
        {
            _context = context;
        }

        public List<Location> GetAll()
        {
            return _context.Locations
                .Include(l => l.Client)
                .ToList();
        }

        public Location GetById(string locationId)
        {
            return _context.Locations
                .Include(l => l.Client)
                .FirstOrDefault(l => l.LocationID == locationId);
        }

        public void Insert(Location location)
        {
            _context.Locations.Add(location);
            _context.SaveChanges();
        }

        public void Update(Location location)
        {
            _context.Entry(location).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(string locationId)
        {
            var location = _context.Locations.Find(locationId);
            if (location != null)
            {
                _context.Locations.Remove(location);
                _context.SaveChanges();
            }
        }

        public List<Location> GetByClientId(string clientId)
        {
            return _context.Locations
                .Where(l => l.ClientID == clientId)
                .ToList();
        }
    }
}
