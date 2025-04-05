using BusinessObjects;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;

        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task<List<Chat>> GetAllChatsAsync() =>
            await _chatRepository.GetAllAsync();

        public async Task<Chat?> GetChatByIdAsync(Guid chatId) =>
            await _chatRepository.GetByIdAsync(chatId);

        public async Task CreateChatAsync(Chat chat) =>
            await _chatRepository.InsertAsync(chat);

        public async Task UpdateChatAsync(Chat chat) =>
            await _chatRepository.UpdateAsync(chat);

        public async Task DeleteChatAsync(Guid chatId) =>
            await _chatRepository.DeleteAsync(chatId);

        public async Task<Chat?> GetChatByClientAndFreelancerAsync(Guid clientId, Guid freelancerId) =>
            await _chatRepository.GetByClientAndFreelancerAsync(clientId, freelancerId);
    }
}
