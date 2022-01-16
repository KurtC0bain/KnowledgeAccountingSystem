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
        [CheckCapitalized]
        [MinLength(2), MaxLength(25)]
        public string FirstName { get; set;}

        [Required]
        [CheckCapitalized]
        [MinLength(2), MaxLength(25)]
        public string LastName { get; set; }

        public ICollection<Knowledge> Knowledge { get; set; }
    }
}
