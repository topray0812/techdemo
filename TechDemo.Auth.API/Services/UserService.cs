using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechDemo.Auth.API.Entities;
using TechDemo.Auth.API.ViewModels;

namespace TechDemo.Auth.API.Services
{
    public class UserService : IUserService
    {
        private AuthDbContext _context;

        public UserService(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<User> Authenticate(UserViewModel userVM)
        {
            try
            {
                var user = await Task.Run(() => _context.Users.SingleOrDefault(u => u.Username == userVM.Username && u.Password == userVM.Password));

                if (user == null)
                    return null;

                return user;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
