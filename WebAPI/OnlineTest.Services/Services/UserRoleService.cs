using OnlineTest.Model.Interface;
using OnlineTest.Model.Repository;
using OnlineTest.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.Services
{
    public class UserRoleService : IUserRoleService
    {
        #region fields
        private readonly IUserRoleRepository _userRoleRepository;
        #endregion
        #region Constr
        public  UserRoleService(IUserRoleRepository  userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }
        #endregion
        #region Methods
        public List<string> GetRoles(int userId)
        {
            return _userRoleRepository.GetRoles(userId);
        }

        #endregion

    }
}
