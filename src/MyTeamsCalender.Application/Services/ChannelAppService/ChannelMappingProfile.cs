using AutoMapper;
using MyTeamsCalender.Domain.Channels;
using MyTeamsCalender.Services.ChannelAppService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamsCalender.Services.ChannelAppService
{
    public class ChannelMappingProfile : Profile
    {
        public ChannelMappingProfile()
        {
            CreateMap<ChannelCreateDto, Channel>()
                .ForMember(a => a.Teams, opt => opt.Ignore())
                .ForMember(a => a.Users, opt => opt.Ignore());
            CreateMap<Channel, ChannelDto>()
                .ForMember(a => a.Teams, opt => opt.MapFrom(a => a.Teams == null ? null : a.Teams));
        }
    }
}
