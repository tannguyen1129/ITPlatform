using BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface ISkillRequirementRepository
    {
        Task<List<SkillRequirement>> GetAllAsync();
        Task<SkillRequirement?> GetByIdAsync(string id);
        Task InsertAsync(SkillRequirement skillRequirement);
        Task UpdateAsync(SkillRequirement skillRequirement);
        Task DeleteAsync(string id);
    }
}
