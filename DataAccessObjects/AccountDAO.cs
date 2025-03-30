using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class AccountDAO
    {
        private readonly MyDbContext _context;
        public AccountDAO(MyDbContext context)
        {
            _context = context;
        }

        public List<Account> GetAll()
        {
            return _context.Accounts.ToList();
        }

        public Account GetById(string accountId)
        {
            return _context.Accounts.Find(accountId);
        }

        public void Insert(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }

        public void Update(Account account)
        {
            _context.Entry(account).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(string accountId)
        {
            var account = _context.Accounts.Find(accountId);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                _context.SaveChanges();
            }
        }

        public Account GetByEmail(string email)
        {
            return _context.Accounts.FirstOrDefault(a => a.Email == email);
        }
    }
}
