using EmpManage.Core.Entities;
using EmpManage.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpManage.Data.Repository
{
    public class PositionRepository : IPositionRepository
    {
        private readonly DataContext _dataContext;

        public PositionRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Position> AddEmployeePositionAsync(Position position)
        {
            _dataContext.Positions.Add(position);
            await _dataContext.SaveChangesAsync();
            return position;
        }

        public async Task DeletePositionAsync(int id)
        {
            var position = await _dataContext.Positions.FindAsync(id);
            if (position != null)
            {
                _dataContext.Positions.Remove(position);
                await _dataContext.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<Position>> GetAllPositionsAsync()
        {
            return await _dataContext.Positions.ToListAsync();
        }

        public async Task<Position> GetPositionByIdAsync(int id)
        {

            return await _dataContext.Positions.FirstOrDefaultAsync(p => p.Id == id);
        }

       
        public async Task<Position> UpdatePositionAsync(int id, Position position)
        {
            var existPosition = await _dataContext.Positions.FindAsync(id);
            if (existPosition != null)
            {
                existPosition.Name = position.Name;
              
            }
            await _dataContext.SaveChangesAsync();
            return  existPosition;
        }

    }
}
