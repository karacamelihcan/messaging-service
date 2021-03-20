using MessagingService.API.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingService.API.Context
{
    public class SeedData
    {
        public static async Task InitalizeAsync(IServiceProvider service)
        {
            await AddSampleData(service.GetRequiredService<MessagingServiceDbContext>());
        }

        public static async Task AddSampleData(MessagingServiceDbContext dbContext)
        {
            if (!dbContext.Users.Any())
            {
                dbContext.Users.Add(new UserEntity
                {
                    ID = 1,
                    Name = "Melihcan",
                    Surname = "Karaca",
                    UserName = "karacamelihcan",
                    Password = "1234"
                });
                dbContext.Users.Add(new UserEntity
                {
                    ID = 2,
                    Name = "Talat",
                    Surname = "Karaca",
                    UserName = "talatkaraca",
                    Password = "4567"
                });
                dbContext.Users.Add(new UserEntity
                {
                    ID = 3,
                    Name = "Ayşe",
                    Surname = "Karaca",
                    UserName = "aysekaraca",
                    Password = "aysek"
                });
                dbContext.Users.Add(new UserEntity
                {
                    ID = 4,
                    Name = "Büşra",
                    Surname = "Elmas",
                    UserName = "belmas",
                    Password = "bkelmas"

                });
            }

            if (!dbContext.Messages.Any())
            {
                dbContext.Messages.Add(new MessageEntity
                {
                    ID = Guid.NewGuid(),
                    SenderID = 1,
                    ReceiverID = 2,
                    Content = "Deneme Mesajı",
                    Date = new DateTime(2020, 01, 12)
                });
                dbContext.Messages.Add(new MessageEntity
                {
                    ID = Guid.NewGuid(),
                    SenderID = 1,
                    ReceiverID = 3,
                    Content = "Deneme Mesajı",
                    Date = new DateTime(2020, 03, 16)
                });
                dbContext.Messages.Add(new MessageEntity
                {
                    ID = Guid.NewGuid(),
                    SenderID = 1,
                    ReceiverID = 4,
                    Content = "Deneme Mesajı",
                    Date = new DateTime(2020, 04, 07)
                });
                dbContext.Messages.Add(new MessageEntity
                {
                    ID = Guid.NewGuid(),
                    SenderID = 2,
                    ReceiverID = 1,
                    Content = "Deneme Mesajı",
                    Date = new DateTime(2020, 06, 19)
                });
                dbContext.Messages.Add(new MessageEntity
                {
                    ID = Guid.NewGuid(),
                    SenderID = 2,
                    ReceiverID = 3,
                    Content = "Deneme Mesajı",
                    Date = new DateTime(2020, 07, 04)
                });
                dbContext.Messages.Add(new MessageEntity
                {
                    ID = Guid.NewGuid(),
                    SenderID = 2,
                    ReceiverID = 4,
                    Content = "Deneme Mesajı",
                    Date = new DateTime(2020, 11, 23)
                });
                dbContext.Messages.Add(new MessageEntity
                {
                    ID = Guid.NewGuid(),
                    SenderID = 3,
                    ReceiverID = 1,
                    Content = "Deneme Mesajı",
                    Date = new DateTime(2020, 02, 24)
                });
                dbContext.Messages.Add(new MessageEntity
                {
                    ID = Guid.NewGuid(),
                    SenderID = 3,
                    ReceiverID = 2,
                    Content = "Deneme Mesajı",
                    Date = new DateTime(2020, 04, 04)
                });
                dbContext.Messages.Add(new MessageEntity
                {
                    ID = Guid.NewGuid(),
                    SenderID = 3,
                    ReceiverID = 4,
                    Content = "Deneme Mesajı",
                    Date = new DateTime(2020, 09, 11)
                });
                dbContext.Messages.Add(new MessageEntity
                {
                    ID = Guid.NewGuid(),
                    SenderID = 4,
                    ReceiverID = 1,
                    Content = "Deneme Mesajı",
                    Date = new DateTime(2020, 05, 24)
                });
                dbContext.Messages.Add(new MessageEntity
                {
                    ID = Guid.NewGuid(),
                    SenderID = 4,
                    ReceiverID = 2,
                    Content = "Deneme Mesajı",
                    Date = new DateTime(2020, 12, 19)
                });
                dbContext.Messages.Add(new MessageEntity
                {
                    ID = Guid.NewGuid(),
                    SenderID = 4,
                    ReceiverID = 3,
                    Content = "Deneme Mesajı",
                    Date = new DateTime(2021, 03, 20)
                });

            }

            await dbContext.SaveChangesAsync();

        }
    }
}
