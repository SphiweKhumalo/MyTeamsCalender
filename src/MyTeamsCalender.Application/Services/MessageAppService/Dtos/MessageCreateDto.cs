using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyTeamsCalender.Domain.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamsCalender.Services.MessageAppService.Dtos
{
    [AutoMap(typeof(Message))]
    public  class MessageCreateDto : EntityDto<Guid>
    {
        public string MessageContent { get; set; }
        public long SenderId { get; set; }
        public long? RecieverId { get; set; }
        public Guid? ChannelId { get; set; } 
    }
}
