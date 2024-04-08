using AutoMapper;
using EmpManage.Core.DTO;
using EmpManage.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpManage.Core.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<EmployeePosition, EmployeePositionDTO>().ReverseMap();
            CreateMap<Position, PositionDTO>().ReverseMap();
        }
    }
}
