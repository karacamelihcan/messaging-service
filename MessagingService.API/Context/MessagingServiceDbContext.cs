using MessagingService.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingService.API.Context
{
    public class MessagingServiceDbContext : DbContext
    {
        public MessagingServiceDbContext(DbContextOptions options) : base(options)
        {

        }
        
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }
        public DbSet<BlockedEntity> Blocks { get; set; }
    }
}
