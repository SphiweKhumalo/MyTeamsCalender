using AutoMapper;
using MyTeamsCalender.Domain.Teams;
using MyTeamsCalender.Services.TeamAppService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamsCalender.Services.TeamMemberAppService.Dtos
{
    public class TeamMappingProfile : Profile
    {
        public TeamMappingProfile()
        {
            CreateMap<TeamCreateDto, Team>()
                .ForMember(x => x.TeamMembers, opt => opt.Ignore())
                .ForMember(x => x.TeamLeader, opt => opt.Ignore()); 
    
        }
    }
}
