namespace ITPlatformUMT.DTOs.Submittions
{
    public class SubmittionCreateDTO
    {
        public string Description { get; set; } = string.Empty;  // ✅ Đổi từ Content sang Description
        public string FreelancerID { get; set; } = string.Empty;
        public string MilestoneID { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;     // ✅ Thêm nếu tạo không có file
        public string Status { get; set; } = "Pending";
    }
}
