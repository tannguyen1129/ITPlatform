using BusinessObjects;

namespace Services.Interfaces
{
    public interface IFreelancerService
    {
        Task<List<Freelancer>> GetAllAsync();
        Task<Freelancer?> GetByIdAsync(string id);
        Task CreateAsync(Freelancer freelancer);
        Task UpdateAsync(Freelancer freelancer);
        Task DeleteAsync(string id);
    }
}
