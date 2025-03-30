using BusinessObjects;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class CertificationService : ICertificationService
    {
        private readonly ICertificationRepository _repo;

        public CertificationService(ICertificationRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Certification>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<Certification?> GetByIdAsync(string id) => await _repo.GetByIdAsync(id);

        public async Task CreateAsync(Certification cert) => await _repo.CreateAsync(cert);

        public async Task UpdateAsync(Certification cert) => await _repo.UpdateAsync(cert);

        public async Task DeleteAsync(string id) => await _repo.DeleteAsync(id);
    }
}
