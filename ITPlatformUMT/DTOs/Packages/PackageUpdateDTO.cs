namespace ITPlatformUMT.DTOs.Packages
{
    public class PackageUpdateDTO
    {
        public string PackageID { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Period { get; set; }
    }
}
