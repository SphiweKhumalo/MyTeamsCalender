using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using MyTeamsCalender.Authorization.Users;
using MyTeamsCalender.Domain.TeamMembers;
using MyTeamsCalender.Domain.Teams;
using MyTeamsCalender.Services.TeamAppService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamsCalender.Services.TeamAppService
{
    public class TeamAppService : AsyncCrudAppService<Team, TeamDto, Guid>
    {
        private readonly IRepository<TeamMembers, Guid> _teamMembersRepository;
        private readonly IRepository<User, long> _userRepository;

        public TeamAppService(IRepository<Team, Guid> repository, IRepository<TeamMembers, Guid> teamMembersRepository, IRepository<User, long> userRepository) : base(repository)
        {
            _teamMembersRepository = teamMembersRepository;
            _userRepository = userRepository;
        }

        public async Task<TeamDto> CreateWithTeam(TeamCreateDto newTeam)
        {
            var team = ObjectMapper.Map<Team>(newTeam);
            team.TeamLeader = _userRepository.Get(newTeam.TeamLeader.Value) ?? null;
            await Repository.InsertAsync(team);
            await AddTeamMembers(newTeam, team);
             team.TeamMembers = _teamMembersRepository.GetAllIncluding(a=>a.User).Where(b => b.Team.Id == team.Id).Select(c => c.User).ToList();
            return ObjectMapper.Map<TeamDto>(team);
        }

        private async Task AddTeamMembers(TeamCreateDto newTeam, Team team)
        {
            if(newTeam.TeamMembers != null)
            {
                foreach (var member in newTeam.TeamMembers)
                {
                    var teamMember = new TeamMembers();
                    teamMember.Team = team;
                    teamMember.User = await _userRepository.GetAsync(member)?? null;
                    await _teamMembersRepository.InsertAsync(teamMember);
                }
               await UnitOfWorkManager.Current.SaveChangesAsync();
            }
           
        }

        [HttpGet]
        public  async Task<List<TeamDto>> GetAllTeamsWithMembers()
        {
            var teams =  Repository.GetAllIncluding(a=>a.TeamLeader);
            var teamDtos = ObjectMapper.Map<List<TeamDto>>(teams);
            foreach (var team in teamDtos)
            {
                team.TeamMembers = _teamMembersRepository.GetAllIncluding(a => a.User).Where(b => b.Team.Id == team.Id).Select(c => c.User.Name).ToList();
            }
            return ObjectMapper.Map<List<TeamDto>>(teamDtos);
        }   
    }
}
