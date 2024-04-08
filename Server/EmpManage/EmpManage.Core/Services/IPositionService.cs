using EmpManage.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpManage.Core.Services
{
    public interface IPositionService
    {
        Task<IEnumerable<Position>> GetAllPositionsAsync();
        Task<Position> GetPositionByIdAsync(int id);
        Task<Position> AddPositionAsync(Position position);
        Task<Position> UpdatePositionAsync(int id, Position position);
        Task DeletePositionAsync(int id); 
    }
}
