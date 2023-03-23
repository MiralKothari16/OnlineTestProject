using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Identity.Client;
using OnlineTest.Model.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Model.Repository
{
    public class UserRoleRepository : IUserRoleRepository
    {
        #region Fields
        private OnlineTestContext _context;
        #endregion

        #region Constr
        public UserRoleRepository(OnlineTestContext context)
        {
            _context = context;
        }
        #endregion

        #region Enum
        private enum RoleMap
        {
            Admin = 1,
            User = 2 
        }
        #endregion
        #region Methods

        public bool AddUserRole(UserRole userRole)
        {
            _context.UserRoles.Add(userRole);
            return _context.SaveChanges() > 0;
        }

        public List<string> GetRoles(int userId)
        {
            var resultrole = _context.UserRoles.Where(x => x.UserId == userId).ToList().OrderBy(r => r.RoleId);
            List<string> roles = new List<string>();
            foreach(var row in resultrole)
            {
                roles.Add(((RoleMap)row.RoleId).ToString());
            }
            return roles;
        }
        #endregion
    }
}
