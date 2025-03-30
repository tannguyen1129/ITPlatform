// SkillInProfileService.cs
using BusinessObjects;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class SkillInProfileService : ISkillInProfileService
    {
        private readonly ISkillInProfileRepository _repo;
        public SkillInProfileService(ISkillInProfileRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<SkillInProfile>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<SkillInProfile?> GetByIdAsync(string id) => await _repo.GetByIdAsync(id);

        public async Task CreateAsync(SkillInProfile entity) => await _repo.InsertAsync(entity);

        public async Task UpdateAsync(SkillInProfile entity) => await _repo.UpdateAsync(entity);

        public async Task DeleteAsync(string id) => await _repo.DeleteAsync(id);
    }
}
