using AutoMapper;
using EmpManage.Core.Entities;
using EmpManage.Models;
using System.Data;

namespace EmpManage.Mapping
{
    public class APIMappingProfile:Profile
    {
        public APIMappingProfile()
        {
            CreateMap<EmployeePostModel, Employee>();
            CreateMap<PositionPostModel, Position>();
            CreateMap<EmployeePositionPostModel, EmployeePosition>();
            
        }
    }
}
