using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class FreelancerDAO
    {
        private readonly MyDbContext _context;

        public FreelancerDAO(MyDbContext context)
        {
            _context = context;
        }

        public List<Freelancer> GetAll()
        {
            return _context.Freelancers
                .Include(f => f.Account)
                .Include(f => f.SubscriptionList)
                .Include(f => f.ExpertiseProfileList)
                .Include(f => f.ApplicationList)
                .Include(f => f.SubmittionList)
                .ToList();
        }

        public Freelancer GetById(string freelancerId)
        {
            return _context.Freelancers
                .Include(f => f.Account)
                .Include(f => f.SubscriptionList)
                .Include(f => f.ExpertiseProfileList)
                .Include(f => f.ApplicationList)
                .Include(f => f.SubmittionList)
                .FirstOrDefault(f => f.FreelancerID == freelancerId);
        }

        public void Insert(Freelancer freelancer)
        {
            _context.Freelancers.Add(freelancer);
            _context.SaveChanges();
        }

        public void Update(Freelancer freelancer)
        {
            _context.Entry(freelancer).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(string freelancerId)
        {
            var freelancer = _context.Freelancers.Find(freelancerId);
            if (freelancer != null)
            {
                _context.Freelancers.Remove(freelancer);
                _context.SaveChanges();
            }
        }

        public Freelancer GetByAccountId(string accountId)
        {
            return _context.Freelancers
                .FirstOrDefault(f => f.AccountID == accountId);
        }

        public List<Freelancer> GetByGender(string gender)
        {
            return _context.Freelancers
                .Where(f => f.Gender == gender)
                .ToList();
        }
    }
}
