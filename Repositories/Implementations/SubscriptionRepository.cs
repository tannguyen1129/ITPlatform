using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly MyDbContext _context;

        public SubscriptionRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Subscription>> GetAllAsync() => await _context.Subscriptions.ToListAsync();

        public async Task<Subscription?> GetByIdAsync(string id) => await _context.Subscriptions.FindAsync(id);

        public async Task InsertAsync(Subscription subscription)
        {
            subscription.SubscriptionID = Guid.NewGuid().ToString();
            _context.Subscriptions.Add(subscription);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Subscription subscription)
        {
            _context.Subscriptions.Update(subscription);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await _context.Subscriptions.FindAsync(id);
            if (entity != null)
            {
                _context.Subscriptions.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
