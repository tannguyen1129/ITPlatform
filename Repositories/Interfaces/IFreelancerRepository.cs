using BusinessObjects;

namespace Repositories.Interfaces
{
    public interface IFreelancerRepository
    {
        Task<IEnumerable<Freelancer>> GetAllAsync();
        Task<Freelancer?> GetByIdAsync(string id);
        Task InsertAsync(Freelancer freelancer);
        Task AddAsync(Freelancer freelancer);
        Task UpdateAsync(Freelancer freelancer);
        Task DeleteAsync(string id);
    }
}
