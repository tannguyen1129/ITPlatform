using BusinessObjects;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repo;

        public ProjectService(IProjectRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Project>> GetAllAsync() => _repo.GetAllAsync();

        public Task<Project?> GetByIdAsync(string id) => _repo.GetByIdAsync(id);

        public Task CreateAsync(Project project) => _repo.InsertAsync(project);

        public Task UpdateAsync(Project project) => _repo.UpdateAsync(project);

        public Task DeleteAsync(string id) => _repo.DeleteAsync(id);
    }
}
