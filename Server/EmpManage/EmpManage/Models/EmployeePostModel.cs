using EmpManage.Core.Entities;

namespace EmpManage.Models
{
    public class EmployeePostModel
    {
        public string Identity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartOfWork { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public bool Active { get; set; }
        public ICollection<EmployeePositionPostModel> EmployeePositions { get; set; }
    }
}
