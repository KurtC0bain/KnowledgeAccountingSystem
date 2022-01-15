using System.Collections.Generic;
using System.Threading.Tasks;
using SystemBLL.DTO.Auth;

namespace SystemBLL.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<string>> AssignUserToRoles(AddRoleToUser addRoleToUser);
        Task CreateRole(string roleName);
        Task<IEnumerable<string>> GetUserRoles(string mail);
        Task<IEnumerable<string>> GetRoles();

    }
}
