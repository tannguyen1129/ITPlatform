using BusinessObjects;
namespace Services.Interfaces
{
    public interface ISubmittionService
    {
        Task<List<Submittion>> GetAllAsync();
        Task<Submittion?> GetByIdAsync(string id);
        Task CreateAsync(Submittion submittion);
        Task UpdateAsync(Submittion submittion);
        Task DeleteAsync(string id);
    }
}