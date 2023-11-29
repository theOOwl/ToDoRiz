using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities.Users;
using System.Threading.Tasks;

namespace Domain.RepoInterface
{
    public interface IUsersRepo
    {
        Task CreateUser(Users user);
        Task<Users> FindUserByMobile(string mobile);
    }
}
