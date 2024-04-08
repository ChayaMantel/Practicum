using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpManage.Core.Entities
{
    public class EmployeePosition
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public bool IsAdministrative { get; set; }
        public DateTime DateOfEntrance { get; set; }
    }
}
