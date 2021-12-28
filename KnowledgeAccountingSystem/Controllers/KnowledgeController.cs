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
        public KnowledgeController(IKnowledgeService knowledgeService)
        {
            _knowledgeService = knowledgeService;
        }

        [HttpGet]
        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> PostKnowledge(Knowledge knowledge)
        {
            await _knowledgeService.AddAsync(knowledge);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteKnowledge(int id)
        {
            await _knowledgeService.DeleteByIdAsync(id);
            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteKnowledge(Knowledge knowledge)
        {
            await _knowledgeService.DeleteAsync(knowledge);
            return Ok();
        }

        [HttpPatch]
        [Authorize]
        public async Task<IActionResult> UpdateKnowledge(Knowledge knowledge)
        {
            await _knowledgeService.UpdateAsync(knowledge);
            return Ok();
        }
    }
}
