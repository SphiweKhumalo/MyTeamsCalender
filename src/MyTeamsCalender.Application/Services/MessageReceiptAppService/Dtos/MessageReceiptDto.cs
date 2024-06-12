using Abp.Application.Services.Dto;
using System;

namespace MyTeamsCalender.Services.MessageReceiptAppService.Dtos
{
    public class MessageReceiptDto : AuditedEntityDto<Guid>
    {
        public string SenderUsername { get; set; }
        public string RecieverUsername { get; set; }
        public DateTime ReadOn { get; set; }

    }
}
