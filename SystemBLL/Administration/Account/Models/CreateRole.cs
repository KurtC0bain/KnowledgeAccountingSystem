using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SystemDAL.Administration.Account.Models
{
    public class CreateRole
    {
        [Required, MaxLength(15), MinLength(3)]
        public string RoleName { get; set; }
    }
}
