using BusinessObjects;

namespace Services.Interfaces
{
    public interface IProjectService
    {
        Task<List<Project>> GetAllAsync();
        Task<Project?> GetByIdAsync(string id);
        Task CreateAsync(Project project);
        Task UpdateAsync(Project project);
        Task DeleteAsync(string id);
    }
}
