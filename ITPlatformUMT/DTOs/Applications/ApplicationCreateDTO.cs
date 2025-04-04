using Microsoft.AspNetCore.Http;

namespace ITPlatformUMT.DTOs.Applications
{
    public class ApplicationCreateDTO
    {
        public string? CV { get; set; } // giữ lại nếu bạn muốn lưu cả base64
        public string? CoverLetter { get; set; }

        public string Status { get; set; } = string.Empty;
        public string FreelancerID { get; set; } = string.Empty;
        public string ProjectID { get; set; } = string.Empty;

        public IFormFile? CVFile { get; set; } // 👈 THÊM DÒNG NÀY
    }
}
