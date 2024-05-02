using Abp.Application.Services.Dto;
using MyTeamsCalender.Authorization.Users;
using MyTeamsCalender.Domain.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamsCalender.Domain.TeamMembers.Dtos
{
    public class TeamMemberDto : AuditedEntityDto<Guid>
    {
        public long User { get; set; }
        public int TeamId { get; set; }
    }
}
