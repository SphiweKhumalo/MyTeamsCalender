using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyTeamsCalender.Authorization.Users;
using MyTeamsCalender.Domain.Channels;
using MyTeamsCalender.Domain.Messages;
using MyTeamsCalender.Domain.Teams;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamsCalender.Services.MessageAppService.Dtos
{
    [AutoMap(typeof(Message))]
    public class MessageDto : EntityDto<Guid>
    {
        public string MessageContent { get; set; }
        public User Sender { get; set; }
        //public long? ChannelId { get; set; }
        public Channel? Channel { get; set; }
        //public long? RecieverId { get; set; }
        public User? Reciever { get; set; }
        public string CreatedByPerson { get; set; }
    }
}
