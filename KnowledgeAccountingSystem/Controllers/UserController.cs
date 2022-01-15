using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using SystemBLL.DTO.Users;
using SystemBLL.UoF;

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

        [HttpPatch]
        [Authorize]
        public async Task<IActionResult> UpdateUser(UserDTO user)
        {
            await _unitOfWork.UserService.UpdateUser(user);
            return Ok();
        }

        [HttpGet]
        [Route("current")]
        public async Task<IActionResult> GetCurrentUser()
        {
            string email = User.FindFirst(ClaimTypes.Name)?.Value;
            if(email == null) { return Ok(null);}
            return Ok(await _unitOfWork.UserService.GetCurrentUser(email));
        }

        [HttpGet]
        [Route("Users")]
        /*[Authorize(Roles = "admin")]*/
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _unitOfWork.UserService.GetAllUsers());
        }

        [HttpGet]
        [Route("{id}")]
        /*[Authorize(Roles = "admin")]*/
        public async Task<IActionResult> GetUserById(string id)
        {
            return Ok(await _unitOfWork.UserService.GetUserById(id));
        }

        [HttpGet]
        [Route("UserId/{email}")]
        public async Task<IActionResult> GetUserId(string email)
        {
            return Ok(await _unitOfWork.UserService.GetUserId(email));
        }

        [HttpGet]
        [Route("UserEmail")]
        public IActionResult GetUserMail()
        {
            return Ok(User.FindFirst(ClaimTypes.Name)?.Value);
        }

    }
}
