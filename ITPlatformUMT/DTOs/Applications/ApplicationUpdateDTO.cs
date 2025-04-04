using Microsoft.AspNetCore.Http;

namespace ITPlatformUMT.DTOs.Applications
{
    public class ApplicationUpdateDTO
    {
        public string? CV { get; set; }
        public string? CoverLetter { get; set; }
        public string? Status { get; set; }
        public string? FreelancerID { get; set; }
        public string? ProjectID { get; set; }

        public IFormFile? CVFile { get; set; } // 👈 THÊM DÒNG NÀY
    }
}
