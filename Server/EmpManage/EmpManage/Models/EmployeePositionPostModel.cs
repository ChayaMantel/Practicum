using EmpManage.Core.Entities;

namespace EmpManage.Models
{
    public class EmployeePositionPostModel
    {
      
        public int PositionId { get; set; }
        public bool IsAdministrative { get; set; }
        public DateTime DateOfEntrance { get; set; }

        
    }
}
