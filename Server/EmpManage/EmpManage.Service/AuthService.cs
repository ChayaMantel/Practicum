using EmpManage.Core.Repositories;
using EmpManage.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpManage.Service
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authrepository)
        {
            _authRepository = authrepository;
        }


        public async Task<bool> HasAdministrativePosition(string identity, string lastName)
        {
            return await _authRepository.HasAdministrativePosition(identity, lastName);
        }
    }
}
