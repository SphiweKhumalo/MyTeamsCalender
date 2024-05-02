using Abp.Application.Services.Dto;
using MyTeamsCalender.Authorization.Users;
using MyTeamsCalender.Domain.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamsCalender.Services.TeamMemberAppService.Dtos
{
    public class TeamMemberDto : EntityDto<Guid>
    {
        public long User { get; set; }
        public int TeamId { get; set; }
    }
}
