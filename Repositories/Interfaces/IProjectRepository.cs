using BusinessObjects;

namespace Repositories.Interfaces
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<Project?> GetByIdAsync(string id);
        Task InsertAsync(Project project);
        Task UpdateAsync(Project project);
        Task DeleteAsync(string id);
    }
}
