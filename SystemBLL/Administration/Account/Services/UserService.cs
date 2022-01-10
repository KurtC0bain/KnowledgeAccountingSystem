using EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Policy;
using System.Threading.Tasks;
using SystemDAL.Administration.Account.Models;
using SystemDAL.Administration.Interfaces;

namespace SystemDAL.Administration.Account.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
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

            }

        }

        public async Task DeleteUser(string email)
        {
            var currentUser = await _userManager.FindByEmailAsync(email);
            var userRoles = await _userManager.GetRolesAsync(currentUser);

            if(userRoles.Count() > 0)
            {
                foreach (var role in userRoles.ToList())
                {
                    var result = await _userManager.RemoveFromRoleAsync(currentUser, role);
                }
            }
            await _userManager.DeleteAsync(currentUser);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var result = await _userManager.Users.Include(x => x.Knowledges).ToListAsync();
            return result;
        }
        public async Task<string> GetUserId(string email) 
        {
            var user = await _userManager.FindByNameAsync(email);
            return user.Id;
        }

        public async Task<Message> ForgotPassword(ForgotPassword model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null) throw new ArgumentNullException();

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var message = new Message(new string[] { user.Email }, "Reset password token", token.ToString());
            return message;
        }
        public async Task<string> ResetPassword(ResetPassword model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            var resetPass = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

            return new String("Please, log in with a new password");
        }
    }
}
