using EmpManage.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpManage.Core.DTO
{
    public class EmployeePositionDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int PositionId { get; set; }
        public bool IsAdministrative { get; set; }
        public DateTime DateOfEntrance { get; set; }


    }
}
