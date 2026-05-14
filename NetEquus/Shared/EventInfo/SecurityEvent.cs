using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.EventInfo
{
    public class SecurityEvent
    {
        public int Id { get; set; }

        public Guid? UserId { get; set; }

        public string EventType { get; set; }

        public string Details { get; set; }

        public string IpAddress { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
