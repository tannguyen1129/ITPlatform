using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class ExpertiseProfileDAO
    {
        private readonly MyDbContext _context;

        public ExpertiseProfileDAO(MyDbContext context)
        {
            _context = context;
        }

        public List<ExpertiseProfile> GetAll()
        {
            return _context.ExpertiseProfiles
                .Include(p => p.CertificationList)
                .Include(p => p.SkillInProfileList)
                .Include(p => p.Freelancer)
                .ToList();
        }

        public ExpertiseProfile GetById(string profileId)
        {
            return _context.ExpertiseProfiles
                .Include(p => p.CertificationList)
                .Include(p => p.SkillInProfileList)
                .Include(p => p.Freelancer)
                .FirstOrDefault(p => p.ProfileID == profileId);
        }

        public void Insert(ExpertiseProfile profile)
        {
            _context.ExpertiseProfiles.Add(profile);
            _context.SaveChanges();
        }

        public void Update(ExpertiseProfile profile)
        {
            _context.Entry(profile).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(string profileId)
        {
            var profile = _context.ExpertiseProfiles.Find(profileId);
            if (profile != null)
            {
                _context.ExpertiseProfiles.Remove(profile);
                _context.SaveChanges();
            }
        }

        public ExpertiseProfile GetByFreelancerId(string freelancerId)
        {
            return _context.ExpertiseProfiles
                .FirstOrDefault(p => p.FreelancerID == freelancerId);
        }

        public List<ExpertiseProfile> GetByField(string field)
        {
            return _context.ExpertiseProfiles
                .Where(p => p.Field == field)
                .ToList();
        }
    }
}