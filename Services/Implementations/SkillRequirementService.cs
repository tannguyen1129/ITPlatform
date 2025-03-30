using BusinessObjects;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class SkillRequirementService : ISkillRequirementService
    {
        private readonly ISkillRequirementRepository _repository;

        public SkillRequirementService(ISkillRequirementRepository repository)
        {
            _repository = repository;
        }

        public Task<List<SkillRequirement>> GetAllAsync() => _repository.GetAllAsync();

        public Task<SkillRequirement?> GetByIdAsync(string id) => _repository.GetByIdAsync(id);

        public Task CreateAsync(SkillRequirement skillRequirement) => _repository.InsertAsync(skillRequirement);

        public Task UpdateAsync(SkillRequirement skillRequirement) => _repository.UpdateAsync(skillRequirement);

        public Task DeleteAsync(string id) => _repository.DeleteAsync(id);
    }
}
