using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyTeamsCalender.Authorization.Users;
using MyTeamsCalender.Domain.Teams;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace MyTeamsCalender.Services.ChannelAppService.Dtos
{
    [AutoMap(typeof(Channel))]
    public class ChannelDto : EntityDto<Guid>
    {
        [MaxLength(50)]
        public string ChannelName { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
        public Team? Teams { get; set; }
        //public Team? TeamId { get; set; }
        //public ICollection<User>? Users { get; set; }

    }
}
