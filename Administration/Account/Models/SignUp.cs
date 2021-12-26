using System;
using System.Collections.Generic;
using System.Text;

namespace Administration.Account.Models
{
    public class SignUp
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Year { get; set; }
    }
}
