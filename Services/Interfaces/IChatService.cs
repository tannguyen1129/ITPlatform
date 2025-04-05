using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessObjects;

namespace Services.Interfaces
{
    public interface IChatService
    {
        Task<List<Chat>> GetAllChatsAsync();
        Task<Chat?> GetChatByIdAsync(Guid chatId);
        Task CreateChatAsync(Chat chat);
        Task UpdateChatAsync(Chat chat);
        Task DeleteChatAsync(Guid chatId);
        Task<Chat?> GetChatByClientAndFreelancerAsync(Guid clientId, Guid freelancerId);
    }
}
