namespace ITPlatformUMT.DTOs.Subscriptions
{
    public class SubscriptionCreateDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? FreelancerID { get; set; }
        public string? ClientID { get; set; }
    }
}
