using EmpManage.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpManage.Core.Repositories
{
    public interface IPositionRepository
    {
        Task<IEnumerable<Position>> GetAllPositionsAsync();
        Task<Position> GetPositionByIdAsync(int id);
        Task<Position> AddEmployeePositionAsync(Position position);
        Task<Position> UpdatePositionAsync(int id, Position position);
        Task DeletePositionAsync(int id); 
    }
}
