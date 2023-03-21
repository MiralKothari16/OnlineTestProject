using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Model.Interface
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        bool AddUser(User user);   
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        //IEnumerable<User> GetUser(int Id);
        User GetUserById(int Id);

        User GetUserByEmail(string Email);

        IEnumerable<User> UserPagination(int page, int content);

    }
}
