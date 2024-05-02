using AutoMapper;
using MyTeamsCalender.Domain.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamsCalender.Services.TeamAppService.Dtos
{
    public class TeamMappingProfile :Profile
    {
        public TeamMappingProfile()
        {
            //CreateMap<Team, TeamDto>();
            CreateMap<TeamDto, Team>()
                .ForMember(x => x.TeamMembers, opt => opt.Ignore());
        }
    }
}
