using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpManage.Core.Entities
{
    public enum Gender
    {
        Male = 1,
        Female
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Identity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartOfWork { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public bool Active { get; set; }
        public ICollection<EmployeePosition> EmployeePositions{ get; set; }
    }
}
