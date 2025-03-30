using BusinessObjects;
namespace Repositories.Interfaces
{
    public interface ISubmittionRepository
    {
        Task<List<Submittion>> GetAllAsync();
        Task<Submittion?> GetByIdAsync(string id);
        Task InsertAsync(Submittion submittion);
        Task UpdateAsync(Submittion submittion);
        Task DeleteAsync(string id);
    }
}