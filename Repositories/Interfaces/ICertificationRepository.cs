using BusinessObjects;

namespace Repositories.Interfaces
{
    public interface ICertificationRepository
    {
        Task<List<Certification>> GetAllAsync();
        Task<Certification?> GetByIdAsync(string id);
        Task CreateAsync(Certification cert);
        Task UpdateAsync(Certification cert);
        Task DeleteAsync(string id);
    }
}
