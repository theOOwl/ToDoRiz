using Domain.Entities.Users;
using Domain.RepoInterface;
using Infrastructure.ToDoRiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepoImplementation
{
    public class UserRepo : IUsersRepo
    {
        private readonly ToDoRizDb _context;
        public UserRepo(ToDoRizDb Context)
        {
            _context = Context;
        }
        public async Task CreateUser(Users user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<Users> FindUserByMobile(string mobile)
        {
           return _context.Users.FirstOrDefault(p => p.Mobile == mobile);
        }
    }
}
