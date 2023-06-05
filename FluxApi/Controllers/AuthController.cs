using AuthCore.Models;
using AuthCore.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Stripe;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace FluxApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        //comment
        [HttpPost,Route("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody]LoginModel user)
        {

            var um = new UserModel();

            try 
            { 
                if (user != null)
                user.Email_Address = user.UserName;

                var res = _authService.IsUserValid(user.UserName, user.Password, user.Email_Address);

                if (res == true)
                {
                    var sercetKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key authnetication"));
                    var signingCredentials = new SigningCredentials(sercetKey, SecurityAlgorithms.HmacSha256);
                    var tokenOptions = new JwtSecurityToken(
                        issuer: "https://localhost:5001",
                        audience: "https://localhost:5001",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(5),
                        signingCredentials: signingCredentials
                        );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                    var result = _authService.Login(user);
                    var _user = _authService.GetUserbyName(user.UserName);
                    um.UserName = _user.UserName;
                    um.ErrorMsg = "this is in error.";

                    _user.Token = tokenString;
                    return Ok(new {Token = tokenString});

                }           
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Unauthorized();

        }

        [HttpPost, Route("signup")]
        [AllowAnonymous]
        public IActionResult Registration([FromBody] RegistrationModel newUser)
        {
            if (newUser == null)
                return BadRequest("");

            StripeConfiguration.ApiKey = "sk_test_51HmMK1Dkg1t2kwCzSkqjEUoJeExNLwxE4r61bvI2RlhtZRouWdu6pvj1IwXVqW3Ofs4mTPxjxaYGPSIfjEgiKR6W00ErbyYaLd";

            var options = new CustomerCreateOptions
            {
                Description = "",
                Email = newUser.Email
            };
            var service = new CustomerService();
            service.Create(options);

            var options2 = new CustomerListOptions
            {
                Limit = 3,
            };
            var service2 = new CustomerService();
            StripeList<Customer> customers = service.List(
              options2
            );
     
            var id = customers.FirstOrDefault();
            newUser.CustId = id.Id;
            var sercetKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key authnetication"));
            var signingCredentials = new SigningCredentials(sercetKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                issuer: "https://localhost:5001",
                audience: "https://localhost:5001",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signingCredentials
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            newUser.Token = tokenString;
            _authService.Register(newUser);
            return Ok();
        }

        [HttpGet, Route("start-timer")]
        public async Task<bool> StartTimer()
        {
            var res = false;
            var timer = new Stopwatch();
            timer.Start();
            long x = timer.ElapsedMilliseconds;

            while (x < 10000)
            {
                x = timer.ElapsedMilliseconds;
            }

            TimeSpan timeTaken = timer.Elapsed;
            var time = timeTaken.TotalMinutes;
            if(time > .01)
            {
                res = true;
            } 
            

            return  res;
        }

        [HttpGet, Route("get-user")]
        public UserModel GetCurrentUser([FromBody] UserModel user)
        {
            var res = _authService.GetUser(user);
            return res;
        }

        
        [HttpGet("is-active")]
        public bool IsUserActive(string username)
        {
            var active = false;
            active = _authService.IsUserActive(username);
            return active;
        }
    }
}
