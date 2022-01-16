using EmailService;
using KnowledgeAccountingSystem.Filters;
using KnowledgeAccountingSystem.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using SystemBLL.DTO.Auth;
using SystemBLL.UoF;

namespace KnowledgeAccountingSystem.Controllers
{
    [ModelStateFilter]
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
            await _unitOfWork.AuthService.SignUp(new SignUp
            {
                FirstName = signUp.FirstName,
                LastName = signUp.LastName,
                Email = signUp.Email,
                Password = signUp.Password,
                Role = signUp.Role,
            });
            return Ok();
                
        }

        [HttpPost]
        [Route("SignIn")]
        public async Task<IActionResult> LogIn(SignIn signIn)
        {
            var user = await _unitOfWork.AuthService.SignIn(signIn);
            var roles = await _unitOfWork.RoleService.GetUserRoles(user.Email);

            var token = JwtHelper.GenerateJwt(user, roles, _jwtSettings);

            HttpContext.Response.Cookies.Append(".AspNetCore.Application.Id", token,
             new CookieOptions
             {
                 MaxAge = TimeSpan.FromDays(30),
                 SameSite = SameSiteMode.None,
                 Secure = true
             });

            return Ok(user.FirstName);
        }

        [HttpPost]
        [Route("SignOut")]
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await _unitOfWork.AuthService.SignOut();
            HttpContext.Response.Cookies.Append(".AspNetCore.Application.Id", "",
                 new CookieOptions
                 {
                     MaxAge = TimeSpan.FromMilliseconds(1),
                     SameSite = SameSiteMode.None,
                     Secure = true
                 });
            return Ok();
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPassword model)
        {
            await _emailSender.SendEmailAsync(await _unitOfWork.AuthService.ForgotPassword(model));
            return Ok("Message sent");
        }
        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPassword model)
        {
            return Ok(await _unitOfWork.AuthService.ResetPassword(model));
        }
    }
}
