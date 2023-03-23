using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Model.Interface
{
    public interface IUserRoleRepository
    {
        List<string>GetRoles(int  userId);
        bool AddUserRole(UserRole userRole);
    }
}
