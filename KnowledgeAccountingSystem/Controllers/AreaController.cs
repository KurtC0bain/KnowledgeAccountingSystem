﻿using Microsoft.AspNetCore.Http;
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
        [Route("{id}")]
        public async Task<IActionResult> GetArea(int id)
        {
            return Ok(await _areaService.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> PostArea(Area area)
        {
            await _areaService.AddAsync(area);
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteArea(int id)
        {
            await _areaService.DeleteByIdAsync(id);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteArea(Area area)
        {
            await _areaService.DeleteAsync(area);
            return Ok();
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateArea(Area area)
        {
            await _areaService.UpdateAsync(area);
            return Ok();
        }
    }

}

