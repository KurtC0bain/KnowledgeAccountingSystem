using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using SystemDAL.Entities.Knowledges;

namespace SystemDAL.Administration.Account.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set;}
        public string LastName { get; set; }
        public ICollection<Knowledge> Knowledge { get; set; }
    }
}
