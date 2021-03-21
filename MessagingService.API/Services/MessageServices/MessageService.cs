using AutoMapper;
using MessagingService.API.Context;
using MessagingService.API.Entities;
using MessagingService.API.Models.RequestModels.Messages;
using MessagingService.API.Models.ResponseModels.Messages;
using MessagingService.API.Services.UserServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingService.API.Services.MessageServices
{
    public class MessageService : IMessageService
    {
        private readonly MessagingServiceDbContext _dbContext;
        private readonly IUserService _userService;


        public MessageService(MessagingServiceDbContext dbContext, IUserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
            
        }

        public async Task<List<MessageView>> GetMessagesByUsername(GetMessagesRequest request)
        {
            var userID = await _userService.GetUserIdByUserName(request.Username);

            if (userID == 0)
                return null;

            var messages = await _dbContext.Messages.Where(msg => msg.ReceiverID == userID).OrderByDescending(msg => msg.Date).ToListAsync();


            if (messages.Count == 0)
                return null;

            var result = new List<MessageView>();

            foreach (var msg in messages)
            {
                var msgview = new MessageView
                {
                    ID = msg.ID,
                    SenderName = await _userService.GetUsernameById(msg.SenderID),
                    ReceiverName = await _userService.GetUsernameById(msg.ReceiverID),
                    Content = msg.Content,
                    Date = msg.Date
                };
                result.Add(msgview);
            }

            return result;

        }

        public async  Task<int> Send(SendMessageRequest request)
        {
            var senderID = await _userService.GetUserIdByUserName(request.SenderName);
            var receiverID = await _userService.GetUserIdByUserName(request.ReceiverName);

            if (senderID == 0 || receiverID == 0)
                return 0;

            var msg = new MessageEntity
            {
                ID = Guid.NewGuid(),
                SenderID = senderID,
                ReceiverID = receiverID,
                Content = request.Content,
                Date = DateTime.Now
            };

            _dbContext.Messages.Add(msg);

            return await _dbContext.SaveChangesAsync();
        }
    }
}
