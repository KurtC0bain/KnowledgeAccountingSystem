using System.ComponentModel.DataAnnotations;

namespace SystemBLL.DTO.Auth
{
    public class CreateRole
    {
        [Required, MaxLength(15), MinLength(3)]
        public string RoleName { get; set; }
    }
}
