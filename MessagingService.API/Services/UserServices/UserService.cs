using MessagingService.API.Context;
using MessagingService.API.Entities;
using MessagingService.API.Models.RequestModels.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingService.API.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly MessagingServiceDbContext _context;
        public UserService(MessagingServiceDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddUser(AddUserRequest request)
        {
            var newUser = new UserEntity
            {
                Name = request.Name,
                Surname = request.Surname,
                UserName = request.UserName,
                Password = request.Password
            };

            _context.Users.Add(newUser);

            return _context.SaveChanges();
        }

        public async Task<int> GetUserIdByUserName(string username)
        {
            var user = await _context.Users.SingleOrDefaultAsync(user => user.UserName == username);

            if (user == null)
                return 0;

            return user.ID;

        }

        public async Task<string> GetUsernameById(int ID)
        {
            var user = await _context.Users.SingleOrDefaultAsync(user => user.ID == ID);

            if (user == null)
                return null;

            return user.UserName;
        }

        public List<UserEntity> GetUsers()
        {
            var userlist =  _context.Users.ToList();

            return userlist;
        }

        public async Task<bool> isUserNameExist(AddUserRequest request)
        {
            var check = await _context.Users.SingleOrDefaultAsync(user => user.UserName == request.UserName);
            if (check == null)
                return false;
            return true;
        }
    }
}
