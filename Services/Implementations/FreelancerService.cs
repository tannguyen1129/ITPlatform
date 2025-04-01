using BusinessObjects;
using Repositories.Interfaces;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class FreelancerService : IFreelancerService
    {
        private readonly IFreelancerRepository _freelancerRepository;

        public FreelancerService(IFreelancerRepository freelancerRepository)
        {
            _freelancerRepository = freelancerRepository;
        }

        public async Task<List<Freelancer>> GetAllAsync() =>
            (await _freelancerRepository.GetAllAsync()).ToList();

        public async Task<Freelancer?> GetByIdAsync(string id) =>
            await _freelancerRepository.GetByIdAsync(id);

        public async Task CreateAsync(Freelancer freelancer)
{
    // ✅ Đảm bảo BirthDate là UTC trước khi lưu
    if (freelancer.BirthDate.Kind == DateTimeKind.Unspecified)
        freelancer.BirthDate = DateTime.SpecifyKind(freelancer.BirthDate, DateTimeKind.Utc);

    await _freelancerRepository.InsertAsync(freelancer);
}

        public async Task UpdateAsync(Freelancer freelancer) =>
            await _freelancerRepository.UpdateAsync(freelancer);

        public async Task DeleteAsync(string id) =>
            await _freelancerRepository.DeleteAsync(id);
    }
}
