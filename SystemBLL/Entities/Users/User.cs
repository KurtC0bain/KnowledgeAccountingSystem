using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SystemDAL.Entities.Knowledges;
using static SystemDAL.Attributes.CustomValidation;

namespace SystemDAL.Entities.Users
{
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set;}

        [Required]
        public string LastName { get; set; }

        public ICollection<Knowledge> Knowledge { get; set; }
    }
}
