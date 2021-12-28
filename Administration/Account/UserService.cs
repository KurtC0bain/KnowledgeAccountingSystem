using Administration.Account.Models;
using Administration.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Account
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public Task AssignUserToRoles(AddRoleToUser addRoleToUser)
        {
            throw new NotImplementedException();
        }

        public async Task CreateRole(string roleName)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
            if (!result.Succeeded)
            {
                throw new Exception($"Role could not be created: {roleName}.");
            }
        }

        public async Task<IEnumerable<IdentityRole>> GetRoles()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<IEnumerable<string>> GetUserRoles(User user)
        {
           return (await _userManager.GetRolesAsync(user)).ToList();
        }

        public async Task<User> SignIn(SignIn model)
        {
            var result = _userManager.Users.SingleOrDefault(x => x.UserName == model.Email);
            if (result is null)
            {
                throw new Exception($"User not found: '{model.Email}'.");
            }
            return await _userManager.CheckPasswordAsync(result, model.Password) ? result : null;
        }

        public async Task SignUp(SignUp model)
        {
            var result = await _userManager.CreateAsync(new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email, 
            }, model.Password);

            if (!result.Succeeded)
            {
                throw new System.Exception(string.Join(';', result.Errors.Select(x => x.Description)));
            }
        }
/*        public async Task ResetPassword(ForgetPassword model)
*/    }
}
