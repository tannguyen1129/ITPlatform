using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class SubmittionDAO
    {
        private readonly DbContext _context;

        public SubmittionDAO(DbContext context)
        {
            _context = context;
        }

        public Submittion GetSubmittionById(string submittionId)
        {
            return _context.Set<Submittion>()
                .Include(s => s.Freelancer)
                .Include(s => s.Milestone)
                .FirstOrDefault(s => s.SubmittionID == submittionId);
        }

        public List<Submittion> GetSubmittionsByFreelancerId(string freelancerId)
        {
            return _context.Set<Submittion>()
                .Where(s => s.FreelancerID == freelancerId)
                .Include(s => s.Milestone)
                .ToList();
        }

        public List<Submittion> GetSubmittionsByStatus(string status)
        {
            return _context.Set<Submittion>()
                .Where(s => s.Status == status)
                .Include(s => s.Freelancer)
                .Include(s => s.Milestone)
                .ToList();
        }

        public void AddSubmittion(Submittion submittion)
        {
            _context.Set<Submittion>().Add(submittion);
            _context.SaveChanges();
        }

        public void UpdateSubmittion(Submittion submittion)
        {
            _context.Set<Submittion>().Update(submittion);
            _context.SaveChanges();
        }

        public void DeleteSubmittion(string submittionId)
        {
            var submittion = _context.Set<Submittion>().Find(submittionId);
            if (submittion != null)
            {
                _context.Set<Submittion>().Remove(submittion);
                _context.SaveChanges();
            }
        }

        public List<Submittion> GetSubmittionsByMilestoneId(string milestoneId)
        {
            return _context.Set<Submittion>()
                .Where(s => s.MilestoneID == milestoneId)
                .Include(s => s.Freelancer)
                .ToList();
        }
    }
}