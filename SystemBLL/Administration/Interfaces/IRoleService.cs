
using System.Collections.Generic;

using System.Threading.Tasks;
using SystemDAL.Administration.Account.Models;

namespace SystemDAL.Administration.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<string>> AssignUserToRoles(AddRoleToUser addRoleToUser);
        Task CreateRole(string roleName);
        Task<IEnumerable<string>> GetUserRoles(string mail);
        Task<IEnumerable<string>> GetRoles();

    }
}
