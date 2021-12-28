using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Administration.Account.Models
{
    public class AddRoleToUser
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string[] Roles { get; set; }
    }
}
