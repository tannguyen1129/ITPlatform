using System;

namespace ITPlatformUMT.DTOs.Messages
{
    public class MessageResponseDTO
    {
        public Guid MessageID { get; set; }
        public Guid ChatID { get; set; }
        public Guid SenderID { get; set; }
        public string SenderRole { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime SentAt { get; set; }
        public bool IsRead { get; set; }
    }
}
