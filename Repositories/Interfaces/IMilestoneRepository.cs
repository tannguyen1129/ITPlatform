using BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IMilestoneRepository
    {
        Task<List<Milestone>> GetAllAsync();
        Task<Milestone?> GetByIdAsync(string id);
        Task InsertAsync(Milestone milestone);
        Task UpdateAsync(Milestone milestone);
        Task DeleteAsync(string id);
    }
}