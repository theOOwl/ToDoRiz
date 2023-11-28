using Application.DTO.UsersDTO;
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
        public async Task CreateUser(UserDTOs userDTOs)
        {
            //O_Mapping
            Users model = new Users()
            {
                Id = userDTOs.Id,
                FullName = userDTOs.FullName,
                Mobile = userDTOs.Mobile,
                Password = userDTOs.Password,
            };
            //
            await _userRepo.CreateUser(model);
        }
    }
}
