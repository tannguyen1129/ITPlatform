namespace ITPlatformUMT.DTOs.Certifications
{
    public class CertificationUpdateDTO
    {
        public string CertID { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public DateTime IssueDate { get; set; }
        public string CertURL { get; set; } = string.Empty;
        public string ProfileID { get; set; } = string.Empty;
    }
}
