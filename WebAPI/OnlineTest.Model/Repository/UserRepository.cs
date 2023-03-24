using Microsoft.EntityFrameworkCore;
using OnlineTest.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Model.Repository
{
    public class UserRepository  :IUserRepository
    {
        #region Field

        private readonly OnlineTestContext _context;

        #endregion

        #region Cntr
        public UserRepository(OnlineTestContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods

        public int AddUser(User user)
        {
            _context.Users.Add(user);
            if(_context.SaveChanges() > 0) { return user.Id; }else {  return 0; }
        }
        public IEnumerable<User> GetUsers()
        {
          // return _context.Users(x => x.IsActive == true ));
           return _context.Users.Where(x=>x.IsActive== true).ToList() ;
        }
        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }
        public User GetUserByEmail (string Email) {
            return _context.Users.FirstOrDefault(x => x.Email == Email);
        }
        public bool UpdateUser(User user) {
            _context.Users.Update(user); 
            return _context.SaveChanges()>0;
        }
        public bool DeleteUser(User user)
        {
            _context.Entry(user).Property("IsActive").IsModified = false;
               return _context.SaveChanges() > 0;
        }
        public IEnumerable<User> UserPagination(int page, int content)
        {
           return _context.Users.Skip((page-1)*content).Take(content).ToList();
        }
        
        #endregion


    }
}
