using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyTeamsCalender.Domain.MessageReceipts;
using System;

namespace MyTeamsCalender.Services.MessageReceiptAppService.Dtos
{
    [AutoMap(typeof(MessageReadReceipt))]
    public class ReadMessageDto : EntityDto<Guid>
    {
        public string Receiver { get; set; }
        public DateTime ReadOn { get; set; }

    }
}
