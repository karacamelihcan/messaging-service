using MessagingService.API.Entities;
using MessagingService.API.Models.RequestModels.Users;
using MessagingService.API.Models.ResponseModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingService.API.Services.UserServices
{
    public interface IUserService
    {
        Task<int> AddUser(AddUserRequest request);
        Task<bool> isUserNameExist(AddUserRequest request);
        List<UserEntity> GetUsers();
        Task<int> GetUserIdByUserName(string username);
        Task<string> GetUsernameById(int ID);
        Task<TokenResponse> Login(LoginRequest request);

    }
}
