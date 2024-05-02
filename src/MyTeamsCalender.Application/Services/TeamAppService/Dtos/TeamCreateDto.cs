using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyTeamsCalender.Authorization.Users;
using MyTeamsCalender.Domain.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamsCalender.Services.TeamAppService.Dtos
{
    [AutoMap(typeof(Team))]
    public class TeamCreateDto : AuditedEntityDto<Guid>
    {
        public string TeamName { get; set; }
        public string Description { get; set; }
        public long? TeamLeader { get; set; }
        public List<long>? TeamMembers { get; set; }

    }
}
