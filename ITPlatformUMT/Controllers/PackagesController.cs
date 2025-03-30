using AutoMapper;
using BusinessObjects;
using ITPlatformUMT.DTOs.Packages;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace ITPlatformUMT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        private readonly IPackageService _service;
        private readonly IMapper _mapper;

        public PackagesController(IPackageService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var packages = await _service.GetAllAsync();
            return Ok(packages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var pkg = await _service.GetByIdAsync(id);
            return pkg == null ? NotFound() : Ok(pkg);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PackageCreateDTO dto)
        {
            var pkg = _mapper.Map<Package>(dto);
            await _service.CreateAsync(pkg);
            return Ok(pkg);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, PackageUpdateDTO dto)
        {
            if (id != dto.PackageID) return BadRequest("ID mismatch");
            var pkg = _mapper.Map<Package>(dto);
            await _service.UpdateAsync(pkg);
            return Ok(pkg);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
