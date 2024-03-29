﻿using System.ComponentModel.DataAnnotations;

namespace SystemBLL.DTO.Auth
{
    public class ForgotPassword
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string ClientURI { get; set; }

    }
}
