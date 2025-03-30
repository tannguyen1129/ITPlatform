using BusinessObjects;

namespace Services.Interfaces
{
    public interface ICertificationService
    {
        Task<List<Certification>> GetAllAsync();
        Task<Certification?> GetByIdAsync(string id);
        Task CreateAsync(Certification cert);
        Task UpdateAsync(Certification cert);
        Task DeleteAsync(string id);
    }
}
