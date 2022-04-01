using Microsoft.AspNetCore.Identity;

namespace eBookShopping.IdentityServer.Model.Context
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}