using EmailService;
using KnowledgeAccountingSystem.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using SystemDAL.Administration.Account.Models;
using SystemDAL.Administration.Interfaces;

namespace KnowledgeAccountingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrationController : ControllerBase
    {
        private readonly IAdministationUnitOfWork _unitOfWork;
        private readonly JwtSettings _jwtSettings;
        private readonly IEmailSender _emailSender;

        public AdministrationController(IAdministationUnitOfWork administationUnitOfWork, IOptionsSnapshot<JwtSettings> jwtSettings, IEmailSender emailSender)
        {
            _unitOfWork = administationUnitOfWork;
            _jwtSettings = jwtSettings.Value;
            _emailSender = emailSender;
        }


        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> Register(SignUp signUp)
        {
            await _unitOfWork.UserService.SignUp(new SignUp
            {
                FirstName = signUp.FirstName,
                LastName = signUp.LastName,
                Email = signUp.Email,
                Password = signUp.Password,
                Role = signUp.Role,
            });
            return Ok();
                
/*                await LogIn(new SignIn
            {
                Email = signUp.Email,
                Password = signUp.Password
            }));
*/        }

        [HttpPost]
        [Route("SignIn")]
        public async Task<IActionResult> LogIn(SignIn signIn)
        {
            var user = await _unitOfWork.UserService.SignIn(new SignIn
            {
                Email = signIn.Email,
                Password = signIn.Password
            });
            if(user is null)
            {
                return BadRequest();
            }

            var roles = await _unitOfWork.RoleService.GetUserRoles(user.Email);

            var token = JwtHelper.GenerateJwt(user, roles, _jwtSettings);

            HttpContext.Response.Cookies.Append(".AspNetCore.Application.Id", token,
             new CookieOptions
             {
                 MaxAge = TimeSpan.FromDays(30),
                 SameSite = SameSiteMode.None,
                 Secure = true
             });

            return Ok(token);
        }

        [HttpPost]
        [Route("SignOut")]
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await _unitOfWork.UserService.SignOut();
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            return Ok();
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPassword model)
        {
            await _emailSender.SendEmailAsync(await _unitOfWork.UserService.ForgotPassword(model));
            return Ok("Message sent");
        }

        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPassword model)
        {
            return Ok(await _unitOfWork.UserService.ResetPassword(model));
        }
    }
}
