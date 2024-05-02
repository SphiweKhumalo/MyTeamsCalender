using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyTeamsCalender.Domain.MessageReceipts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamsCalender.Services.MessageReceiptAppService.Dtos
{
    public class MessageReceiptDto : AuditedEntityDto<Guid>
    {
        public string SenderUsername { get; set; }
        public string RecieverUsername { get; set; }
        public DateTime ReadOn { get; set; }

    }
}
