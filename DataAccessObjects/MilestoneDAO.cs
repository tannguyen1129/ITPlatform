using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class MilestoneDAO
    {
        private readonly MyDbContext _context;

        public MilestoneDAO(MyDbContext context)
        {
            _context = context;
        }

        public List<Milestone> GetAll()
        {
            return _context.Milestones
                .Include(m => m.Project)
                .Include(m => m.SubmittionList)
                .ToList();
        }

        public Milestone GetById(string milestoneId)
        {
            return _context.Milestones
                .Include(m => m.Project)
                .Include(m => m.SubmittionList)
                .FirstOrDefault(m => m.MilestoneID == milestoneId);
        }

        public void Insert(Milestone milestone)
        {
            _context.Milestones.Add(milestone);
            _context.SaveChanges();
        }

        public void Update(Milestone milestone)
        {
            _context.Entry(milestone).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(string milestoneId)
        {
            var milestone = _context.Milestones.Find(milestoneId);
            if (milestone != null)
            {
                _context.Milestones.Remove(milestone);
                _context.SaveChanges();
            }
        }

        public List<Milestone> GetByProjectId(string projectId)
        {
            return _context.Milestones
                .Where(m => m.ProjectID == projectId)
                .Include(m => m.SubmittionList)
                .ToList();
        }

        public List<Milestone> GetByStatus(string status)
        {
            return _context.Milestones
                .Where(m => m.Status == status)
                .ToList();
        }
    }
}
