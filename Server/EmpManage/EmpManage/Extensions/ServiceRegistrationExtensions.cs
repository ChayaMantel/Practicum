using AutoMapper;
using EmpManage.Core.Mapping;
using EmpManage.Core.Repositories;
using EmpManage.Core.Services;
using EmpManage.Data.Repository;
using EmpManage.Mapping;
using EmpManage.Service;

namespace EmpManage.Extensions
{
    public static class ServiceRegistrationExtensions
    {
        public static void ConfigurationService(this IServiceCollection services)
        {

            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAuthRepository, AuthRepository>();

            services.AddAutoMapper(typeof(MappingProfile), typeof(APIMappingProfile));

        }
    }
}
