namespace ITPlatformUMT.DTOs.Subscriptions
{
    public class SubscriptionUpdateDTO
    {
        public string SubscriptionID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? FreelancerID { get; set; }
        public string? ClientID { get; set; }
    }
}
