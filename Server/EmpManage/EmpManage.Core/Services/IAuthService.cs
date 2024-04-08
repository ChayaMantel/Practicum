using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpManage.Core.Services
{
    public interface IAuthService
    {
        public Task<bool> HasAdministrativePosition(string identity, string lastname);
    }
}
