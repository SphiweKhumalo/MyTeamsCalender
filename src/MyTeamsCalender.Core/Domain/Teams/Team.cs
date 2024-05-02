using Abp.Domain.Entities.Auditing;
using MyTeamsCalender.Authorization.Users;
using MyTeamsCalender.Domain.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamsCalender.Domain.Teams
{
    public class Team : AuditedEntity<Guid>
    {
        public string TeamName { get; set; }
        public string Description { get; set; }
        public User? TeamLeader { get; set; }
        public List<User>? TeamMembers { get; set; } = new List<User>();
    }
}
