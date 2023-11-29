using Application.DTO.RegisterDTO;
using Application.DTO.UsersDTO;
using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.ServiceInterface
{
    public interface IUserService
    {
        Task CreateUser(RegisterDTOs registerDTOs);
        Task<Users> FindUserByMobile(string userMobile);
    }
}
