using Administration;
using Administration.Account.Models;
using Administration.Interfaces;
using KnowledgeAccountingSystem.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace KnowledgeAccountingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtSettings _jwtSettings;

        public AdministrationController(IUserService userService, IOptionsSnapshot<JwtSettings> jwtSettings)
        {
            _userService = userService;
            _jwtSettings = jwtSettings.Value;
        }
        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> Register(SignUp signUp)
        {
            await _userService.SignUp(new SignUp
            {
                FirstName = signUp.FirstName,
                LastName = signUp.LastName,
                Email = signUp.Email,
                Password = signUp.Password,
                Year = signUp.Year,
            });
            return Ok();
        }

        [HttpPost]
        [Route("SignIn")]
        public async Task<IActionResult> LogIn(SignIn signIn)
        {
            var user = await _userService.SignIn(new SignIn
            {
                Email = signIn.Email,
                Password = signIn.Password
            });
            if(user is null)
            {
                return BadRequest();
            }
            var roles = await _userService.GetUserRoles(user);
            return Ok(JwtHelper.GenerateJwt(user, roles, _jwtSettings));
        }


        [HttpPost]
        [Route("NewRole")]
        public async Task<IActionResult> AddRole(CreateRole role)
        {
            await _userService.CreateRole(role.RoleName);
            return Ok();
        }


        [HttpGet]
        [Route("Roles")]
        public async Task<IActionResult> GetRoles()
        {
            return Ok(await _userService.GetRoles());
        }
        [HttpGet]
        [Route("UserRole")]
        public async Task<IActionResult> GetUserRoles(User user)
        {
            return Ok(await _userService.GetUserRoles(user));
        }
    }
}
