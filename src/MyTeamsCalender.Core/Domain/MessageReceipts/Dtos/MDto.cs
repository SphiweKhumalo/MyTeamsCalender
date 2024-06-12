using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyTeamsCalender.Authorization.Users;
using MyTeamsCalender.Domain.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamsCalender.Domain.MessageReceipts.Dtos
{
    [AutoMap(typeof(MessageReadReceipt))]   
    public class MDto : EntityDto<Guid>
    {
        public Message Message { get; set; }
        public User Receiver { get; set; }
        public DateTime ReadOn { get; set; }
    }
}
