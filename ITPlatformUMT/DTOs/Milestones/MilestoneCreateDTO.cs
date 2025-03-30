namespace ITPlatformUMT.DTOs.Milestones
{
    public class MilestoneCreateDTO
    {
        public double Budget { get; set; }
        public string Status { get; set; } = string.Empty;
        public string ProjectID { get; set; } = string.Empty;
    }
}
