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
        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
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
            else
            {
                var currentUser = await _userManager.FindByEmailAsync(model.Email);

                var roleresult = await _userManager.AddToRoleAsync(currentUser, model.Role);
                await SignIn(new SignIn
                {
                    Email = model.Email,
                    Password = model.Password
                });
            }

        }


        /*        public async Task ResetPassword(ForgetPassword model)
        */
    }
}
