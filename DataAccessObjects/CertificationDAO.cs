using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class CertificationDAO
    {
        private readonly MyDbContext _context;

        public CertificationDAO(MyDbContext context)
        {
            _context = context;
        }

        public List<Certification> GetAll()
        {
            return _context.Certifications
                .Include(c => c.ExpertiseProfile)
                .ToList();
        }

        public Certification GetById(string certId)
        {
            return _context.Certifications
                .Include(c => c.ExpertiseProfile)
                .FirstOrDefault(c => c.CertID == certId);
        }

        public void Insert(Certification certification)
        {
            _context.Certifications.Add(certification);
            _context.SaveChanges();
        }

        public void Update(Certification certification)
        {
            _context.Entry(certification).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(string certId)
        {
            var certification = _context.Certifications.Find(certId);
            if (certification != null)
            {
                _context.Certifications.Remove(certification);
                _context.SaveChanges();
            }
        }

        public List<Certification> GetByProfileId(string profileId)
        {
            return _context.Certifications
                .Where(c => c.ProfileID == profileId)
                .ToList();
        }
    }
}