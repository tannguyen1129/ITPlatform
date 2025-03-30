using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class PackageDAO
    {
        private readonly MyDbContext _context;

        public PackageDAO(MyDbContext context)
        {
            _context = context;
        }

        public List<Package> GetAll()
        {
            return _context.Packages
                .Include(p => p.SubscriptionList)
                .ToList();
        }

        public Package GetById(string packageId)
        {
            return _context.Packages
                .Include(p => p.SubscriptionList)
                .FirstOrDefault(p => p.PackageID == packageId);
        }

        public void Insert(Package package)
        {
            _context.Packages.Add(package);
            _context.SaveChanges();
        }

        public void Update(Package package)
        {
            _context.Entry(package).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(string packageId)
        {
            var package = _context.Packages.Find(packageId);
            if (package != null)
            {
                _context.Packages.Remove(package);
                _context.SaveChanges();
            }
        }

        public List<Package> GetByType(string type)
        {
            return _context.Packages
                .Where(p => p.Type == type)
                .ToList();
        }
    }
}
