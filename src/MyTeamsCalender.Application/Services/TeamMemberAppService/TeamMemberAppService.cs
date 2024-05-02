using Abp.Application.Services;
using Abp.Domain.Repositories;
using MyTeamsCalender.Domain.TeamMembers;
using MyTeamsCalender.Domain.TeamMembers.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamsCalender.Services.TeamMemberAppService
{
    public class TeamMemerAppService : AsyncCrudAppService<TeamMembers, TeamMemberDto, Guid>
    {
        public TeamMemerAppService(IRepository<TeamMembers, Guid> repository) : base(repository)
        {
        }
    }
}
