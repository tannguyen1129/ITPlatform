using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class ClientDAO
    {
        private readonly MyDbContext _context;

        public ClientDAO(MyDbContext context)
        {
            _context = context;
        }

        public List<Client> GetAll()
        {
            return _context.Clients
                .Include(c => c.Account)
                .Include(c => c.LocationList)
                .Include(c => c.SubscriptionList)
                .Include(c => c.ProjectList)
                .ToList();
        }

        public Client GetById(string clientId)
        {
            return _context.Clients
                .Include(c => c.Account)
                .Include(c => c.LocationList)
                .Include(c => c.SubscriptionList)
                .Include(c => c.ProjectList)
                .FirstOrDefault(c => c.ClientID == clientId);
        }

        public void Insert(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public void Update(Client client)
        {
            _context.Entry(client).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(string clientId)
        {
            var client = _context.Clients.Find(clientId);
            if (client != null)
            {
                _context.Clients.Remove(client);
                _context.SaveChanges();
            }
        }

        public Client GetByAccountId(string accountId)
        {
            return _context.Clients
                .FirstOrDefault(c => c.AccountID == accountId);
        }

        public List<Client> GetByField(string field)
        {
            return _context.Clients
                .Where(c => c.Field == field)
                .ToList();
        }
    }
}