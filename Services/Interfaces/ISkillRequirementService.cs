using BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ISkillRequirementService
    {
        Task<List<SkillRequirement>> GetAllAsync();
        Task<SkillRequirement?> GetByIdAsync(string id);
        Task CreateAsync(SkillRequirement skillRequirement);
        Task UpdateAsync(SkillRequirement skillRequirement);
        Task DeleteAsync(string id);
    }
}
