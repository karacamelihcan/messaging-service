using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingService.API.Entities
{
    public class BlockedEntity
    {
        public Guid Id { get; set; }
        public int KickerID { get; set; }
        public int BlockedID { get; set; }
        public DateTime Date { get; set; }
    }
}
