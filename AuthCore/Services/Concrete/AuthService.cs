using AuthCore.Models;
using AuthCore.Repositories.Abstract;
using AuthCore.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthCore.Services.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        public void DeleteUserAccount(UserModel user)
        {
            _authRepository.DeleteUserAccount(user);
        }

        public UserModel GetUser(UserModel user)
        {
            return _authRepository.GetUser(user);
        }

        public UserModel GetUserbyName(string name)
        {
            return _authRepository.GetUserbyName(name);
        }

        public bool IsUserActive(string username)
        {
            return _authRepository.IsUserActive(username);
        }

        public bool IsUserValid(string username, string pw, string email)
        {
            return _authRepository.IsUserValid(username, pw, email);
        }

        public UserModel Login(LoginModel login)
        {
            return _authRepository.Login(login);
        }

        public void Register(RegistrationModel newUser)
        {
             _authRepository.Register(newUser);
        }

        public void SignOut(UserModel user)
        {
            _authRepository.SignOut(user);
        }
    }
}
