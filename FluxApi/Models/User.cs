using Microsoft.AspNetCore.Identity;

namespace FluxApi.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
