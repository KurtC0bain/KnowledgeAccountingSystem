using System.ComponentModel.DataAnnotations;
using static SystemDAL.Attributes.CustomValidation;

namespace SystemBLL.DTO.Auth
{
    public class SignUp
    {

        [Required]
        [MinLength(2), MaxLength(25)]
        [CheckCapitalized]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2), MaxLength(25)]
        [CheckCapitalized]
        public string LastName { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Password should contain of more than 6 symbols", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Passwords are not the same")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
