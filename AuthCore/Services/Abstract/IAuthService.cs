using AuthCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthCore.Services.Abstract
{
    public interface IAuthService
    {
        void Register(RegistrationModel newUser);  //create new user
        void DeleteUserAccount(UserModel user); //delete user
        void SignOut(UserModel user);  //sign out
        UserModel Login(LoginModel login); //user login
        bool IsUserValid(string username, string pw, string email); //check user validation
        UserModel GetUser(UserModel user);
        UserModel GetUserbyName(string name);
        bool IsUserActive(string username);


        //edit user account here....
    }
}
