using Abp.Domain.Entities.Auditing;
using MyTeamsCalender.Authorization.Users;
using MyTeamsCalender.Domain.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamsCalender.Domain.MessageReceipts
{
    public class MessageReadReceipt : AuditedEntity<Guid>
    {
        public Message Message { get; set; }
        public User Receiver { get; set; }
        public DateTime ReadOn { get; set; }
    }
}
