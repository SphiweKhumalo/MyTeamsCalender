using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyTeamsCalender.Authorization.Users;
using MyTeamsCalender.Domain.Channels;
using MyTeamsCalender.Domain.MessageReceipts.Dtos;
using MyTeamsCalender.Domain.Messages;
using MyTeamsCalender.Domain.Teams;
using MyTeamsCalender.Services.MessageReceiptAppService.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamsCalender.Services.MessageAppService.Dtos
{
    public class MessageGetAllDto : EntityDto<Guid>
    {
        public string MessageContent { get; set; }
        public string Sender { get; set; }
        //public long? ChannelId { get; set; }
        public string? Channel { get; set; }
        //public long? RecieverId { get; set; }
        public string? Reciever { get; set; }
        public DateTime? CreationTime { get; set; }
        //public List<MessageReadReceiptDto> ReadReceipts { get; set; }
        //public MessageReadReceiptDto ReadReceipts { get; set; }
    }
}
