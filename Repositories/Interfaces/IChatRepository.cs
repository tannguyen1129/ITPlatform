using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IChatRepository
    {
        Task<List<Chat>> GetAllAsync();
        Task<Chat?> GetByIdAsync(Guid id);
        Task<Chat?> GetByClientAndFreelancerAsync(Guid clientID, Guid freelancerID);
        Task InsertAsync(Chat chat);
        Task UpdateAsync(Chat chat);
        Task DeleteAsync(Guid id);
    }
}
