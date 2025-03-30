namespace ITPlatformUMT.DTOs.Projects
{
    public class ProjectCreateDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double BudgetMin { get; set; }
        public double BudgetMax { get; set; }
        public string Status { get; set; } = string.Empty;
        public string ClientID { get; set; } = string.Empty;
    }
}
