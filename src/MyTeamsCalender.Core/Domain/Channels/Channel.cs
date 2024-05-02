using Abp.Domain.Entities.Auditing;
using MyTeamsCalender.Authorization.Users;
using MyTeamsCalender.Domain.Teams;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamsCalender.Domain.Channels
{
    public class Channel : AuditedEntity<Guid>
    {
        [MaxLength(50)]
        public string ChannelName { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
        public Team? Teams { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
