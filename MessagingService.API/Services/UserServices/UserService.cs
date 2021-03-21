using MessagingService.API.Context;
using MessagingService.API.Entities;
using MessagingService.API.Models.RequestModels.Users;
using MessagingService.API.Models.ResponseModels.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;

namespace MessagingService.API.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly MessagingServiceDbContext _context;
        private readonly IConfiguration _configuration;
        public UserService(MessagingServiceDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
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

        public async Task<TokenResponse> Login(LoginRequest request)
        {
            if(string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password))
            {
                return null;
            }
            var user = await _context.Users.SingleOrDefaultAsync(user => user.UserName == request.UserName && user.Password == request.Password);

            if (user == null)
                return null;

            var secretKey = _configuration.GetValue<string>("JwtTokenKey");
            var tokenHandler = new JwtSecurityTokenHandler();

            var singingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var tokenDesc = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(singingKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var newToken = tokenHandler.CreateToken(tokenDesc);
            var tokenResponse = new TokenResponse
            {
                UserName = user.UserName,
                ExpireTime = tokenDesc.Expires ?? DateTime.Now.AddHours(1),
                Token = tokenHandler.WriteToken(newToken)
            };

            return tokenResponse;
        }
    }
}
