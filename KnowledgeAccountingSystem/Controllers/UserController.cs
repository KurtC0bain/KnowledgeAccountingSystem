﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using SystemDAL.Administration.Interfaces;

namespace KnowledgeAccountingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAdministationUnitOfWork _unitOfWork;
        public UserController(IAdministationUnitOfWork administationUnitOfWork)
        {
            _unitOfWork = administationUnitOfWork;
        }

        [HttpPost]
        [Route("DeleteUser/{mail}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteUser(string mail)
        {
            await _unitOfWork.UserService.DeleteUser(mail);
            return Ok();
        }

        [HttpGet]
        [Route("Users")]
        /*[Authorize(Roles = "admin")]*/
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _unitOfWork.UserService.GetAllUsers());
        }
        [HttpGet]
        [Route("UserId")]
        public async Task<IActionResult> GetUserId()
        {
            string email = User.FindFirst(ClaimTypes.Name)?.Value;
            return Ok(await _unitOfWork.UserService.GetUserId(email));
        }
    }
}
