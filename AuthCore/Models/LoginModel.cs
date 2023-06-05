using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthCore.Models
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Email_Address { get; set; }
        public string Password { get; set; }
    }
}
