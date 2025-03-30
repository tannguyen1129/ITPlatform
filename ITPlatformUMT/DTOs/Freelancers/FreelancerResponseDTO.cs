namespace ITPlatformUMT.DTOs.Freelancers
{
    public class FreelancerResponseDTO
    {
        public string FreelancerID { get; set; } = string.Empty;
        public string CIN { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string AccountID { get; set; } = string.Empty;
    }
}
