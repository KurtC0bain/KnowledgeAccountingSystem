using Administration;
using Administration.Account.Models;
using Administration.Interfaces;
using KnowledgeAccountingSystem.Helpers;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IAdministationUnitOfWork _unitOfWork;
        private readonly JwtSettings _jwtSettings;

        public AdministrationController(IAdministationUnitOfWork administationUnitOfWork, IOptionsSnapshot<JwtSettings> jwtSettings)
        {
            _unitOfWork = administationUnitOfWork;
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost]
        [Route("AssignUserToRole")]
        public async Task<IActionResult> AssingUserToRole(AddRoleToUser addRoleToUser)
        {
            return Ok(await _unitOfWork.RoleService.AssignUserToRoles(addRoleToUser));
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
            return Ok(await LogIn(new SignIn
            {
                Email = signUp.Email,
                Password = signUp.Password
            }));
        }

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
            return Ok(JwtHelper.GenerateJwt(user, roles, _jwtSettings));
        }

        [HttpPost]
        [Route("DeleteUser")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteUser(string mail)
        {
            await _unitOfWork.UserService.DeleteUser(mail);
            return Ok();
        }

        [HttpGet]
        [Route("Users")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _unitOfWork.UserService.GetAllUsers());
        }

        [HttpPost]
        [Route("NewRole")]
        public async Task<IActionResult> AddRole(CreateRole role)
        {
            await _unitOfWork.RoleService.CreateRole(role.RoleName);
            return Ok();
        }


        [HttpGet]
        [Route("Roles")]
        public async Task<IActionResult> GetRoles()
        {
            return Ok(await _unitOfWork.RoleService.GetRoles());
        }

        [HttpPost]
        [Route("UserRole")]
        public async Task<IActionResult> GetUserRoles(string mail)
        {
            return Ok(await _unitOfWork.RoleService.GetUserRoles(mail));
        }
    }
}
