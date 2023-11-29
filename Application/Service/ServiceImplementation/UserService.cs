using Application.DTO.RegisterDTO;
using Application.DTO.UsersDTO;
using Application.Security;
using Application.Service.ServiceInterface;
using Domain.Entities.Users;
using Domain.RepoInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.ServiceImplementation
{
    public class UserService : IUserService
    {
        #region ctor
        private readonly IUsersRepo _userRepo;
        public UserService(IUsersRepo userRepo)
        {
            _userRepo = userRepo;   
        }
        #endregion
        public async Task CreateUser(RegisterDTOs registerDTOs)
        {
            //O_Mapping
            Users model = new Users()
            {
                Id = registerDTOs.Id,
                FullName = registerDTOs.FullName,
                Mobile = registerDTOs.Mobile.Trim(),
                Password = PasswordHelper.MD5Hash(registerDTOs.Password)
            };
            //
            await _userRepo.CreateUser(model);
        }

        public async Task<Users> FindUserByMobile(string userMobile)
        {
           return await _userRepo.FindUserByMobile(userMobile);
        }
    }
}
