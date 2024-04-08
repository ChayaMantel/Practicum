using EmpManage.Core.Entities;
using EmpManage.Core.Repositories;
using EmpManage.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpManage.Service
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;

        public PositionService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

      

        public async Task<Position> AddPositionAsync(Position position)
        {
            return await _positionRepository.AddEmployeePositionAsync(position);
        }

        public async Task DeletePositionAsync(int id)
        {
            await _positionRepository.DeletePositionAsync(id);
        }

        public async Task<IEnumerable<Position>> GetAllPositionsAsync()
        {
           return await _positionRepository.GetAllPositionsAsync();
        }

        public async Task<Position> GetPositionByIdAsync(int id)
        {
            return await _positionRepository.GetPositionByIdAsync(id);
        }

        public async Task<Position> UpdatePositionAsync(int id, Position position)
        {
            return await _positionRepository.UpdatePositionAsync(id, position); 
        }
    }
}
