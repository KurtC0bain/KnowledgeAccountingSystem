using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemBLL.DTO.Auth;
using SystemBLL.Interfaces;
using SystemDAL.Entities.Users;

namespace SystemBLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task CreateRole(string roleName)
        {
            if (_roleManager.Roles.Select(r => r.NormalizedName).Contains(roleName.ToUpper()))
                throw new ArgumentException($"Role with name '{roleName}' already exists");

            var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
            if (!result.Succeeded)
            {
                throw new Exception($"Role could not be created: {roleName}.");
            }
        }

        public async Task<IEnumerable<string>> GetRoles()
        {
            return await _roleManager.Roles.Select(x => x.NormalizedName).ToListAsync();
        }

        public async Task<IEnumerable<string>> GetUserRoles(string mail)
        {
            var currentUser = await _userManager.FindByEmailAsync(mail);
            if(currentUser == null)
                throw new ArgumentException($"User with email '{mail}' does not exists");

            return await _userManager.GetRolesAsync(currentUser);
        }

        public async Task<IEnumerable<string>> AssignUserToRoles(AddRoleToUser addRoleToUser)
        {
            var currentUser = await _userManager.FindByEmailAsync(addRoleToUser.Email);
            if (currentUser == null)
                throw new ArgumentException($"User with email '{addRoleToUser.Email}' does not exists");

            var roles = _roleManager.Roles.ToList().Where(r => addRoleToUser.Roles.Contains(r.Name, StringComparer.OrdinalIgnoreCase))
                .Select(r => r.NormalizedName).ToList();

            var result = await _userManager.AddToRolesAsync(currentUser, roles);

            if (!result.Succeeded)
            {
                throw new System.Exception(string.Join(';', result.Errors.Select(x => x.Description)));
            }
            return roles;
        }
    }
}
