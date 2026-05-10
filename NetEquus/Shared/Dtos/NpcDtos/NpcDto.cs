using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Dtos.NpcDtos
{
    public class NpcDto
    {
        public Guid NpcId { get; set; }
        public string Username { get; set; }
        public bool IsNpc { get; set; }
        public bool CanLogin { get; set; }

        public string EstateName { get; set; }

        public Guid? EstateId { get; set; }
    }

    public class CreateNpcDto
    {
        public string Username { get; set; }
        public bool IsNpc { get; set; }
        public bool CanLogin { get; set; }

    }
}
