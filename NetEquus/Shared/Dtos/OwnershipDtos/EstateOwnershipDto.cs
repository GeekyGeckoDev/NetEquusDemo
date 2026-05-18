using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.OwnershipDtos
{
    public class EstateOwnershipDto
    {

        public Guid? EquineEstateId { get; set; }

        public Guid UserId { get; set; }


        //public bool isPrimaryOwner { get; set; }
    }
}
