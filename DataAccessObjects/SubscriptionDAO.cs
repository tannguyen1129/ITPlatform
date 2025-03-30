using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class SubscriptionDAO
    {
        private readonly DbContext _context;

        public SubscriptionDAO(DbContext context)
        {
            _context = context;
        }

        public Subscription GetSubscriptionById(string subscriptionId)
        {
            return _context.Set<Subscription>()
                .Include(s => s.Freelancer)
                .Include(s => s.Client)
                .FirstOrDefault(s => s.SubscriptionID == subscriptionId);
        }

        public List<Subscription> GetSubscriptionsByFreelancerId(string freelancerId)
        {
            return _context.Set<Subscription>()
                .Where(s => s.FreelancerID == freelancerId)
                .ToList();
        }

        public List<Subscription> GetSubscriptionsByClientId(string clientId)
        {
            return _context.Set<Subscription>()
                .Where(s => s.ClientID == clientId)
                .ToList();
        }

        public void AddSubscription(Subscription subscription)
        {
            _context.Set<Subscription>().Add(subscription);
            _context.SaveChanges();
        }

        public void UpdateSubscription(Subscription subscription)
        {
            _context.Set<Subscription>().Update(subscription);
            _context.SaveChanges();
        }

        public void DeleteSubscription(string subscriptionId)
        {
            var subscription = _context.Set<Subscription>().Find(subscriptionId);
            if (subscription != null)
            {
                _context.Set<Subscription>().Remove(subscription);
                _context.SaveChanges();
            }
        }

        public List<Subscription> GetActiveSubscriptions()
        {
            var now = DateTime.Now;
            return _context.Set<Subscription>()
                .Where(s => s.StartDate <= now && s.EndDate >= now)
                .Include(s => s.Freelancer)
                .Include(s => s.Client)
                .ToList();
        }
    }
}