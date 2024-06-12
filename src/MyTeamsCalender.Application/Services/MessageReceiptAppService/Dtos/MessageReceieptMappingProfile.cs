using AutoMapper;
using MyTeamsCalender.Domain.MessageReceipts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamsCalender.Services.MessageReceiptAppService.Dtos
{
    public class MessageReceiptMappingProfile : Profile
    {
        public MessageReceiptMappingProfile()
        {
            CreateMap<MessageReadReceipt, MessageReadReceiptDto>()
                .ForMember(a => a.Message, x => x.MapFrom(a => a.Message))
                .ForMember(a => a.Receiver, x => x.MapFrom(a => a.Receiver))
                .ForMember(a => a.ReadOn, x => x.MapFrom(a => a.ReadOn));
            CreateMap<MessageReadReceipt, ReadMessageDto>()
                .ForMember(a => a.Receiver, x => x.MapFrom(a => a.Receiver.FullName));
        }
    }
}
