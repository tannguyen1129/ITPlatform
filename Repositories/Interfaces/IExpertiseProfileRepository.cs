using BusinessObjects;

namespace Repositories.Interfaces
{
    public interface IExpertiseProfileRepository
    {
        Task<List<ExpertiseProfile>> GetAllAsync();
        Task<ExpertiseProfile?> GetByIdAsync(string id);
        Task InsertAsync(ExpertiseProfile profile);
        Task UpdateAsync(ExpertiseProfile profile);
        Task DeleteAsync(string id);
    }
}
