using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTeamsCalender.Authorization.Users;
using MyTeamsCalender.Domain.Channels;
using MyTeamsCalender.Domain.MessageReceipts;
using MyTeamsCalender.Domain.Messages;
using MyTeamsCalender.Domain.TeamMembers;
using MyTeamsCalender.Services.ChannelAppService.Dtos;
using MyTeamsCalender.Services.MessageAppService.Dtos;
using MyTeamsCalender.Services.MessageReceiptAppService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamsCalender.Services.MessageAppService
{
    public class MessageAppService : AsyncCrudAppService<Message, MessageDto, Guid>
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
        public async Task<List<MessageGetAllDto>> GetAllMessagesAsync()
        {
            var messages = await Repository.GetAllIncluding(a => a.Sender, b => b.Reciever, c => c.Channel).ToListAsync();
            var messageGet = new List<MessageGetAllDto>();
            var mRead = await _messageReadReceiptRepository.GetAllListAsync(a => messages.Contains(a.Message));

            try
            {
                messages.ForEach(a =>
                {
                    messageGet.Add(new MessageGetAllDto
                    {
                        Id = Guid.NewGuid(),
                        MessageContent = a.MessageContent,
                        Sender = a.Sender.UserName,
                        Reciever = a.Reciever.UserName,
                        Channel = a.Channel?.ChannelName,
                        CreationTime = a.CreationTime,
                        //ReadReceipts = ObjectMapper.Map<MessageReadReceiptDto>(mRead)
                    });
                });
                //foreach (var message in messages)
                //{
                //    messageGet.Add(new MessageGetAllDto
                //    {
                //        MessageContent = message.MessageContent,
                //        Sender = message.Sender.UserName,
                //        Reciever = message.Reciever.UserName,
                //        Channel = message.Channel?.ChannelName,
                //        CreationTime = message.CreationTime,
                //        ReadReceipts = ObjectMapper.Map<List<MessageReadReceiptDto>>(mRead)
                //    });
                //}
            }
            catch (Exception e)
            {

                throw new UserFriendlyException(e.Message);
            }


            try{ Console.WriteLine(messageGet); return ObjectMapper.Map<List<MessageGetAllDto>>(messageGet); } catch(Exception e) { Console.WriteLine(e.Message); return null; }
        }
        //read message
        [HttpPut]
        public async Task<MessageDto> ReadMessageAsync(MessageReceiptDto readDetails) //for one user chat
        {
            var chats = Repository.GetAll().Where(a => a.Sender.UserName == readDetails.SenderUsername && a.Reciever.UserName == readDetails.RecieverUsername).ToList();
            var toReadMessages = _messageReadReceiptRepository.GetAllIncluding(a => a.Message).Where(a => !chats.Contains(a.Message)).Select(a => a.Message).ToList();
            if (toReadMessages.Count == 0)
            {
                foreach (var message in chats)
                {
                    var messageReadMessage = new MessageReadReceipt();
                    messageReadMessage.Message = message;
                    messageReadMessage.Receiver = await _userRepository.FirstOrDefaultAsync(a => a.UserName == readDetails.RecieverUsername);
                    messageReadMessage.ReadOn = DateTime.Now;
                    _messageReadReceiptRepository.InsertAsync(messageReadMessage);
                }
            }
            return null;
        }
    }
}
