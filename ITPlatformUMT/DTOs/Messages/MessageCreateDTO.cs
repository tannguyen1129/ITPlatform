using System;

namespace ITPlatformUMT.DTOs.Messages
{
    public class MessageCreateDTO
    {
        public Guid ChatID { get; set; }
        public Guid SenderID { get; set; }
        public string SenderRole { get; set; } = string.Empty; // "Client" hoặc "Freelancer"
        public string Content { get; set; } = string.Empty;
    }
}
