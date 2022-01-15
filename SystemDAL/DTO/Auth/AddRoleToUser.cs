using System.ComponentModel.DataAnnotations;

namespace SystemBLL.DTO.Auth
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
