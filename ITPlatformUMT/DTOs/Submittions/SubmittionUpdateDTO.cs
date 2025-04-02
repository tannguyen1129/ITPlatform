namespace ITPlatformUMT.DTOs.Submittions
{
    public class SubmittionUpdateDTO
    {
        public string SubmittionID { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;  // ✅ Đổi từ Content sang Description
        public string FilePath { get; set; } = string.Empty;     // ✅ Để cho phép cập nhật file
        public string Status { get; set; } = string.Empty;
        public string FreelancerID { get; set; } = string.Empty;
        public string MilestoneID { get; set; } = string.Empty;
    }
}
