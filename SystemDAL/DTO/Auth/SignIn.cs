using System.ComponentModel.DataAnnotations;

namespace SystemBLL.DTO.Auth
{
    public class SignIn
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
