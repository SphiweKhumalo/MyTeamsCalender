using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using MyTeamsCalender.Domain.MessageReceipts;
using MyTeamsCalender.Domain.Messages;
using MyTeamsCalender.Domain.TeamMembers;
using MyTeamsCalender.Domain.TeamMembers.Dtos;
using MyTeamsCalender.Services.MessageReceiptAppService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamsCalender.Services.TeamMemberAppService
{
    public class MessageRecieptAppService : AsyncCrudAppService<MessageReadReceipt, MessageReadReceiptDto, Guid>
    {
        private readonly IRepository<Message, Guid> _messageRepository;
        public MessageRecieptAppService(IRepository<MessageReadReceipt, Guid> repository, IRepository<Message, Guid> messageRepository) : base(repository)
        {
            _messageRepository = messageRepository;
        }

        //public async Task<MessageReadReceiptDto> CreateMessageReceipt(MessageReadReceiptDto recieptDto)
        //{
        //    var receipt = new MessageReadReceipt()
        //    {
        //        Message = await _messageRepository.GetAsync(recieptDto.MessageId),
        //        Receiver =  Repository.GetAllIncluding(a => a.Receiver).Where(a => a.Receiver.Id == recieptDto.Reciever.Id).Select(b => b.Receiver).FirstOrDefault(),
        //    };
        //    return ObjectMapper.Map<MessageReadReceiptDto>(await Repository.InsertAsync(receipt));

        //}
       // get all
        public async Task<List<MessageReadReceiptDto>> GetAllMessageReceipts()
        {
            var receipts = await Repository.GetAllIncluding(a => a.Receiver).ToListAsync();
            return ObjectMapper.Map<List<MessageReadReceiptDto>>(receipts); 
        }
    }
}
