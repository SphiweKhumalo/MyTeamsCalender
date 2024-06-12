using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTeamsCalender.Authorization.Users;
using MyTeamsCalender.Domain.Channels;
using MyTeamsCalender.Domain.MessageReceipts;
using MyTeamsCalender.Domain.Messages;
using MyTeamsCalender.Services.MessageAppService.Dtos;
using MyTeamsCalender.Services.MessageReceiptAppService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTeamsCalender.Services.MessageAppService
{
    public class MessageAppService : AsyncCrudAppService<Message, MessageDto, Guid, PagedAndSortedResultRequestDto, MessageDto>
    {
        private readonly IRepository<User, long> _userRepository;
        private readonly IRepository<Channel, Guid> _channelRepository;
        private readonly IRepository<MessageReadReceipt, Guid> _messageReadReceiptRepository;
        public MessageAppService(IRepository<Message, Guid> repository, IRepository<User, long> userRepository, IRepository<Channel, Guid> channelRepository, IRepository<MessageReadReceipt, Guid> messageReadReceiptRepositor) : base(repository)
        {
            _userRepository = userRepository;
            _channelRepository = channelRepository;
            _messageReadReceiptRepository = messageReadReceiptRepositor;
        }
        [HttpPost]
        //create Message 
        public async Task<MessageDto> CreateMessageAsync(MessageCreateDto messageDetails)
        {
            var message = ObjectMapper.Map<Message>(messageDetails);
            message.Sender = await _userRepository.GetAsync(messageDetails.SenderId);
            if (messageDetails.ChannelId != null)
            {
                message.Channel = await _channelRepository.GetAsync(messageDetails.ChannelId.Value);
            }
            if (messageDetails.RecieverId.HasValue)
            {
                message.Reciever = await _userRepository.GetAsync(messageDetails.RecieverId.Value);
            }

            await Repository.InsertAsync(message);
            await CurrentUnitOfWork.SaveChangesAsync();
            //return ObjectMapper.Map<MessageDto>(message);
            return null;  ///FIX
        }
        [HttpGet]
        //getall messages with reciever,channel and sender
        public async Task<List<MessageDto>> GetAllMessagesAsync()
        {
            var messages = await Repository.GetAllIncluding(a => a.Sender, b => b.Reciever, c => c.Channel).ToListAsync();

            return ObjectMapper.Map<List<MessageDto>>(messages);
        }
        public async Task<List<MessageGetAllDto>> GetAllMessagesForUserAsync(string sender, string reciever)
        {
            if (sender == null || reciever == null)
            {
                throw new UserFriendlyException("Sender or Reciever cannot be null");
            }
            var messages = await Repository.GetAllIncluding(a => a.Sender, b => b.Reciever, c => c.Channel)
                                            .Where(s => s.Sender.UserName == sender
                                                    && s.Reciever.UserName == reciever
                                                    || s.Reciever.UserName == sender
                                                    && s.Sender.UserName == reciever)
                                            .ToListAsync();

            var messageGet = new List<MessageGetAllDto>();

            if (messages is not null)
            {
                var mRead = await _messageReadReceiptRepository.GetAllListAsync(a => messages.Contains(a.Message));
                messages.ForEach(a =>
                {
                    messageGet.Add(new MessageGetAllDto
                    {
                        Id = a.Id,
                        MessageContent = a.MessageContent,
                        Sender = a.Sender.UserName,
                        Reciever = a.Reciever.UserName,
                        Channel = a.Channel?.ChannelName,
                        CreationTime = a.CreationTime,
                        ReadReceipts = mRead.Count > 0 ? ObjectMapper.Map<List<ReadMessageDto>>(mRead.Where(b => b.Message.Id == a.Id)) : null
                    });
                });
            }
            return messageGet;
        }

        //read message
        [HttpPut]
        public async Task<MessageReadReceiptDto> ReadMessageAsync(MessageReceiptDto readDetails) //for one user chat
        {
            var chats = Repository.GetAll().Where(a => a.Sender.UserName == readDetails.SenderUsername && a.Reciever.UserName == readDetails.RecieverUsername).ToList();
            //VALIDATE NOT READING SAME MESSAGE AS RECEIPT
            var toReadMessages = _messageReadReceiptRepository.GetAllIncluding(a => a.Message).Where(a => !chats.Contains(a.Message)).Select(a => a.Message).ToList();
            var messageReadMessage = new MessageReadReceipt();

            if (toReadMessages.Count > 0)
            {
                foreach (var message in chats)
                {
                    messageReadMessage.Message = message;
                    messageReadMessage.Receiver = await _userRepository.FirstOrDefaultAsync(a => a.UserName == readDetails.RecieverUsername);
                    messageReadMessage.ReadOn = DateTime.Now;
                    await _messageReadReceiptRepository.InsertAsync(messageReadMessage);
                }
            }
            return ObjectMapper.Map<MessageReadReceiptDto>(messageReadMessage);
        }
    }
}
