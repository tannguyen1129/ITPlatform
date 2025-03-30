using BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IMilestoneService
    {
        Task<List<Milestone>> GetAllAsync();
        Task<Milestone?> GetByIdAsync(string id);
        Task CreateAsync(Milestone milestone);
        Task UpdateAsync(Milestone milestone);
        Task DeleteAsync(string id);
    }
}