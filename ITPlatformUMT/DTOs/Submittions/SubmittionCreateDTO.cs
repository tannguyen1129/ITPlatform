namespace ITPlatformUMT.DTOs.Submittions
{
    public class SubmittionCreateDTO
    {
        public string Content { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";
        public string FreelancerID { get; set; } = string.Empty;
        public string MilestoneID { get; set; } = string.Empty;
    }
}
