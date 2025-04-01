using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ITPlatformUMT.DTOs.Submittions
{
    public class SubmittionCreateWithFileDTO
    {
        public string MilestoneID { get; set; } = string.Empty;
        public string FreelancerID { get; set; } = string.Empty; // 👈 Bắt buộc
        public string? Description { get; set; }
        public IFormFile? File { get; set; }
    }
}
