using Abp.Application.Services;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using MyTeamsCalender.Domain.Channels;
using MyTeamsCalender.Domain.Teams;
using MyTeamsCalender.Services.ChannelAppService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamsCalender.Services.ChannelAppService
{
    public class ChannelAppService : AsyncCrudAppService<Channel, ChannelDto, Guid>
    {
        private readonly IRepository<Team, Guid> _teamRepository;
        public ChannelAppService(IRepository<Channel, Guid> repository, IRepository<Team, Guid> teamRepository) : base(repository)
        {
            _teamRepository = teamRepository;   
        }

        [HttpPost]
        //create channel
        public async Task<ChannelDto> CreateChannel(ChannelCreateDto input)
        {
            var channel = ObjectMapper.Map<Channel>(input);
            channel.Teams = input.TeamId != null ? await _teamRepository.GetAsync((Guid)input.TeamId) : null;
            var result = await Repository.InsertAsync(channel);
            return ObjectMapper.Map<ChannelDto>(result);
        }
    }
}
