using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SystemBLL.Interfaces;
using SystemDAL.Entities.Knowledges;

namespace KnowledgeAccountingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KnowledgeController : ControllerBase
    {
        private readonly IKnowledgeService _knowledgeService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public KnowledgeController(IKnowledgeService knowledgeService, IHttpContextAccessor httpContextAccessor)
        {
            _knowledgeService = knowledgeService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult GetKnowledge()
        {
            return Ok(_knowledgeService.GetAllAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetKnowledge(int id)
        {
            return Ok(await _knowledgeService.GetByIdAsync(id));
        }

        [HttpPost]
        /*[Authorize(Roles = "programmer, admin")]*/
        public async Task<IActionResult> PostKnowledge(Knowledge knowledge)
        {
            /*            knowledge.UserId = _httpContextAccessor.User.FindFirstValue(CalimTypes.NameIdentifier);
            */
            await _knowledgeService.AddAsync(knowledge);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        /*      [Authorize(Roles = "programmer, admin")]*/
        public async Task<IActionResult> DeleteKnowledgeById(int id)
        {
            await _knowledgeService.DeleteByIdAsync(id);
            return Ok();
        }

        [HttpDelete]
        /*        [Authorize(Roles = "programmer, admin")]
        */
        public async Task<IActionResult> DeleteKnowledge(Knowledge knowledge)
        {
            await _knowledgeService.DeleteAsync(knowledge);
            return Ok();
        }

        [HttpPatch]
/*        [Authorize(Roles = "programmer, admin")]
*/        public async Task<IActionResult> UpdateKnowledge(Knowledge knowledge)
        {
            await _knowledgeService.UpdateAsync(knowledge);
            return Ok();
        }

        [HttpGet]
        [Route("user/{id}")]
        public async Task<IActionResult> GetUserKnowledge(string id)
        {
            return Ok(await _knowledgeService.GetUserKnowledge(id));
        }
    }
}
