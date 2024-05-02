using AutoMapper;
using MyTeamsCalender.Domain.MessageReceipts;
using MyTeamsCalender.Domain.MessageReceipts.Dtos;
using MyTeamsCalender.Domain.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamsCalender.Services.MessageAppService.Dtos
{
    public class MessageMappingProfile : Profile
    {
        public MessageMappingProfile()
        {
            CreateMap<MessageCreateDto, Message>()
                .ForMember(a => a.Sender, opt => opt.Ignore())
                .ForMember(a => a.Reciever, opt => opt.Ignore());
            CreateMap<Message, MessageGetAllDto>()
                            .ForMember(a => a.Sender, x => x.MapFrom(a => a.Sender.Name + a.Sender.Surname))
                             .ForMember(a => a.Reciever, x => x.MapFrom(a => a.Reciever.Name + a.Reciever.Surname))
                             .ForMember(a => a.CreationTime, x => x.MapFrom(a => a.CreationTime))
                             .ForMember(a => a.Channel, x => x.MapFrom(a => a.Channel.ChannelName));
                             //.ForMember(a => a.ReadReceipts, b => b.Ignore());
            //CreateMap<MessageReadReceipt, MessageReadReceiptDto>()
            //    .ForMember(a => a.Message, x => x.MapFrom(a => a.Message))
            //    .ForMember(a => a.Receiver, x => x.MapFrom(a => a.Receiver))
            //    .ForMember(a => a.ReadOn, x => x.MapFrom(a => a.ReadOn));

        }
    }
}
