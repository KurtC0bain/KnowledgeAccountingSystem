using KnowledgeAccountingSystem.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SystemBLL.DTO.Auth;
using SystemBLL.UoF;

namespace KnowledgeAccountingSystem.Controllers
{
    [ModelStateFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IAdministationUnitOfWork _unitOfWork;

        public RoleController(IAdministationUnitOfWork administationUnitOfWork)
        {
            _unitOfWork = administationUnitOfWork;
        }

        [HttpPost]
        [Route("NewRole")]
        [Authorize(Roles = "admin")]
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

        [HttpGet]
        [Route("UserRole/{mail}")]
        public async Task<IActionResult> GetUserRoles(string mail)
        {
            return Ok(await _unitOfWork.RoleService.GetUserRoles(mail));
        }
        [HttpPost]
        [Route("AssignUserToRole")]
        public async Task<IActionResult> AssingUserToRole(AddRoleToUser addRoleToUser)
        {
            return Ok(await _unitOfWork.RoleService.AssignUserToRoles(addRoleToUser));
        }

    }
}
