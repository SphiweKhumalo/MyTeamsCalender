using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyTeamsCalender.Authorization.Users;
using MyTeamsCalender.Domain.Channels;
using MyTeamsCalender.Domain.Teams;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamsCalender.Services.ChannelAppService.Dtos
{
    [AutoMap(typeof(Channel))]
    public class ChannelCreateDto : EntityDto<Guid> 
    {
        public string ChannelName { get; set; }
        public string? Description { get; set; }
        public Guid? TeamId { get; set; }
        public ICollection<long>? Users { get; set; }

    }
}


