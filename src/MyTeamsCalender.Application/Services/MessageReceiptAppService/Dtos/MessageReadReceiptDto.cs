using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyTeamsCalender.Authorization.Users;
using MyTeamsCalender.Domain.MessageReceipts;
using MyTeamsCalender.Domain.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamsCalender.Services.MessageReceiptAppService.Dtos
{
    [AutoMap(typeof(MessageReadReceipt))]
    public class MessageReadReceiptDto : EntityDto<Guid>
    {
        public Message Message { get; set; }
        public User Receiver { get; set; }
        public DateTime? ReadOn { get; set; }

    }
}
