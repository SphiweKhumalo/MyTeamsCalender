using Abp.Domain.Entities.Auditing;
using MyTeamsCalender.Authorization.Users;
using MyTeamsCalender.Domain.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamsCalender.Domain.TeamMembers
{
    public class TeamMembers : AuditedEntity<Guid>
    {
        public User User { get; set; }
        public Team Team { get; set; }
    }
}
