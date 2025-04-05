using System;
using System.Collections.Generic;

namespace ITPlatformUMT.DTOs.Chat
{
    public class ChatResponseDTO
    {
        public Guid ChatID { get; set; }
        public Guid ClientID { get; set; }
        public Guid FreelancerID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastMessageAt { get; set; }
    }
}
