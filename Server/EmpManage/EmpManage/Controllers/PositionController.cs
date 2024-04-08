using AutoMapper;
using EmpManage.Core.DTO;
using EmpManage.Core.Entities;
using EmpManage.Core.Services;
using EmpManage.Models;
using EmpManage.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmpManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService;
        private readonly IMapper _mapper;

        public PositionController(IPositionService positionService, IMapper mapper)
        {
            _positionService = positionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Position>>>  Get()
        {
            var positions = await _positionService.GetAllPositionsAsync();
            var positionsDTO = _mapper.Map<IEnumerable<PositionDTO>>(positions);
            return Ok(positionsDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Position>> Get(int id)
        {
            var position = await _positionService.GetPositionByIdAsync(id);
            if (position == null)
                return NotFound($"Position with ID {id} not found.");

            var positionDTO = _mapper.Map<PositionDTO>(position);
            return Ok(positionDTO);
        }

        [HttpPost]
        public async Task<ActionResult<Position>> Post([FromBody] PositionPostModel position)
        {
            var positionToAdd = _mapper.Map<Position>(position);
            await _positionService.AddPositionAsync(positionToAdd);

            var addedPositionDTO = _mapper.Map<PositionDTO>(positionToAdd);
            return Ok(addedPositionDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Position>> Put(int id, [FromBody] PositionPostModel position)
        {
            var positionToUpdate = _mapper.Map<Position>(position);
            var positioPost=await  _positionService.UpdatePositionAsync(id, positionToUpdate);
            if (positioPost == null)
                return NotFound($"Position with ID {id} not found.");
            var updatedPositionDTO = _mapper.Map<PositionDTO>(positionToUpdate);
            return Ok(updatedPositionDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _positionService.DeletePositionAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound($"Position with ID {id} not found.");
            }
        }
    }
}
