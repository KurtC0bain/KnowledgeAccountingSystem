using EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemBLL.DTO.Auth;
using SystemBLL.Interfaces;
using SystemDAL.Entities.Users;

namespace SystemBLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        public AuthService(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
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
        public async Task<Message> ForgotPassword(ForgotPassword model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null) throw new ArgumentNullException();

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var param = new Dictionary<string, string>
            {
                {"token", token },
                {"email", model.Email }
            };
            var callback = QueryHelpers.AddQueryString(model.ClientURI, param);

            var message = new Message(new string[] { user.Email }, "Reset password token", callback);

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
