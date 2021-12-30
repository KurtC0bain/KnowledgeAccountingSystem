﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SystemDAL.Administration.Account.Models
{
    public class ForgetPassword
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
