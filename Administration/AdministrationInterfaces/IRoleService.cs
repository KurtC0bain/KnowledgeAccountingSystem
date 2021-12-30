using Administration.Account.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<string>> AssignUserToRoles(AddRoleToUser addRoleToUser);
        Task CreateRole(string roleName);
        Task<IEnumerable<string>> GetUserRoles(string mail);
        Task<IEnumerable<string>> GetRoles();

    }
}
