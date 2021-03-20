using AutoMapper;
using MessagingService.API.Context;
using MessagingService.API.Entities;
using MessagingService.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingService.API.Infrastructure
{
    public class MappingProfile : Profile
    {
        private readonly MessagingServiceDbContext _dbContext;

        public MappingProfile(MessagingServiceDbContext dbContext)
        {
            _dbContext = dbContext;

            CreateMap<MessageEntity, MessageView>()
                .ForMember(dest => dest.SenderName,
                    opt => opt.MapFrom(msg => _dbContext.Users.SingleOrDefault(src => src.ID == msg.SenderID).UserName))
                .ForMember(dest => dest.ReceiverName,
                    opt => opt.MapFrom(msg => _dbContext.Users.SingleOrDefault(src => src.ID == msg.ReceiverID).UserName));
                    
                
        }
    }
}
