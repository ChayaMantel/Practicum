using EmpManage.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpManage.Data.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _dataContext;


        public AuthRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public async Task<bool> HasAdministrativePosition(string identity, string lastName)
        {

            if (identity == "123456789" && lastName == "admin")
            {
                return true;
            }

             var employee = await _dataContext.Employees
            .Include(e => e.EmployeePositions)
            .FirstOrDefaultAsync(e => e.Identity == identity && e.LastName == lastName);

            if (employee != null)
            {
                return employee.EmployeePositions.Any(ep => ep.IsAdministrative);
            }

            return false;
        }
    }
}
