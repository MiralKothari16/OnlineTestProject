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
        private readonly OnlineTestContext _context;

        public UserRepository(OnlineTestContext context)
        {
            _context = context; 
        }
        public bool AddUser(User user)
        {
            _context.Users.Add(user);
            return _context.SaveChanges() >0;
        }
        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList()  ;
        }

        public bool UpdateUser(User user) {
            _context.Users.Update(user);
            return _context.SaveChanges()>0;
        }
        public bool DeleteUser(int Id) {
            var del = _context.Users.Find(Id);
            if (del != null)
            { _context.Users.Remove(del); }
                return _context.SaveChanges() > 0;
            
        }
    }
}
