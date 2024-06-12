using Abp.Application.Services.Dto;
using MyTeamsCalender.Services.MessageReceiptAppService.Dtos;
using System;
using System.Collections.Generic;

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
        public List<ReadMessageDto> ReadReceipts { get; set; }
        //public MessageReadReceiptDto ReadReceipts { get; set; }
    }
}
