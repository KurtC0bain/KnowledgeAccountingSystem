using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using SystemDAL.Entities.Knowledges;

namespace SystemDAL.Entities.Users
{
    public class User : IdentityUser
    {
        public string FirstName { get; set;}
        public string LastName { get; set; }
        public ICollection<Knowledge> Knowledge { get; set; }
    }
}
