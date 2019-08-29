using System;
using System.Threading.Tasks;
using TechDemo.Auth.API.Entities;
using TechDemo.Auth.API.ViewModels;

namespace TechDemo.Auth.API.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(UserViewModel userVM);
    }
}
