using OnlineTest.Services.DTO;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.GetDTO;
using OnlineTest.Services.DTO.UpdateDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.Interface
{
    public interface IUserService
    {
        ResponseDTO GetUsers();
        ResponseDTO UserPagination(int page, int content);
        ResponseDTO AddUser(AddUserDTO user);
        ResponseDTO UpdateUser(UpdateUserDTO user);
        ResponseDTO DeleteUser(int Id);
        ResponseDTO GetUserById(int Id);
        ResponseDTO GetUserByEmail(string Email);
        // use for authentication
        GetUserDTO IsUserExists(TokenDTO model);
    }
}
