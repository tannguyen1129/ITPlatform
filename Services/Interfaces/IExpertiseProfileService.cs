using BusinessObjects;

namespace Services.Interfaces
{
    public interface IExpertiseProfileService
    {
        Task<List<ExpertiseProfile>> GetAllAsync();
        Task<ExpertiseProfile?> GetByIdAsync(string id);
        Task CreateAsync(ExpertiseProfile profile);
        Task UpdateAsync(ExpertiseProfile profile);
        Task DeleteAsync(string id);
    }
}
