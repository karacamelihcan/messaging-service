using MessagingService.API.Models.ResponseModels.Messages;
using MessagingService.API.Models.RequestModels.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingService.API.Services.MessageServices
{
    public interface IMessageService
    {
        Task<List<MessageView>> GetMessagesByUsername(GetMessagesRequest request);
        Task<int> Send(SendMessageRequest request);
    }
}
