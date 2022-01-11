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
    public class AreaController : ControllerBase
    {
        private readonly IAreaService _areaService;
        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        [HttpGet]
        public IActionResult GetArea()
        {
            return Ok(_areaService.GetAllAsync());
        }

        [HttpGet]
        [Route("FullAreas")]
        public async Task<IActionResult> FindFullAreas()
        {
            return Ok(await _areaService.FindFullAreas());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetArea(int id)
        {
            return Ok(await _areaService.GetByIdAsync(id));
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> PostArea(Area area)
        {
            await _areaService.AddAsync(area);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteAreaById(int id)
        {
            await _areaService.DeleteByIdAsync(id);
            return Ok();
        }
        
        [HttpDelete]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteArea(Area area)
        {
            await _areaService.DeleteAsync(area);
            return Ok();
        }
        
        [HttpPatch]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateArea(Area area)
        {
            await _areaService.UpdateAsync(area);
            return Ok();
        }

        [HttpGet]
        [Route("knowledge/{id}")]
        public async Task<IActionResult> GetKnowladgeAreasById(int id)
        {
            return  Ok(await _areaService.GetKnowledgeAreasById(id));
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> GetAreaIdByName(string areaName)
        {
            return Ok(await _areaService.GetAreaIdByName(areaName));
        }

        [HttpGet]
        [Route("/AvRating/{id}")]
        public async Task<IActionResult> GetAreaAverageRating(int id)
        {
            
            return Ok(await _areaService.GetAverageAreaRating(id));
        }
    }

}

