using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class ApplicationDAO
    {
        private readonly MyDbContext _context;

        public ApplicationDAO(MyDbContext context)
        {
            _context = context;
        }

        public List<Application> GetAll()
        {
            return _context.Applications
                .Include(a => a.Freelancer)
                .Include(a => a.Project)
                .ToList();
        }

        public Application GetById(string applicationId)
        {
            return _context.Applications
                .Include(a => a.Freelancer)
                .Include(a => a.Project)
                .FirstOrDefault(a => a.ApplicationID == applicationId);
        }

        public void Insert(Application application)
        {
            _context.Applications.Add(application);
            _context.SaveChanges();
        }

        public void Update(Application application)
        {
            _context.Entry(application).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(string applicationId)
        {
            var application = _context.Applications.Find(applicationId);
            if (application != null)
            {
                _context.Applications.Remove(application);
                _context.SaveChanges();
            }
        }

        public List<Application> GetByFreelancerId(string freelancerId)
        {
            return _context.Applications
                .Where(a => a.FreelancerID == freelancerId)
                .Include(a => a.Project)
                .ToList();
        }

        public List<Application> GetByProjectId(string projectId)
        {
            return _context.Applications
                .Where(a => a.ProjectID == projectId)
                .Include(a => a.Freelancer)
                .ToList();
        }
    }
}
