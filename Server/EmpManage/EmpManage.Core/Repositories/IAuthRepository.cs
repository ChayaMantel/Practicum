using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpManage.Core.Repositories
{
    public interface IAuthRepository
    {
        public Task<bool> HasAdministrativePosition(string identity, string lastname);
    }
}
