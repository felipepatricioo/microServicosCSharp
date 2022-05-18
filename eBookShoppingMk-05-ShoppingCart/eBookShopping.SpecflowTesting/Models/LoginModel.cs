using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookShopping.SpecflowTesting.Models
{
    internal class LoginModel
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; }
        public string client_id { get; set; }   
        public string client_secret { get; set; }
        public string grant_type { get; set; }
    }
}
