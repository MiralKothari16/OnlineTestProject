using OnlineTest.Model;
using OnlineTest.Model.Interface;
using OnlineTest.Model.Interface;
using OnlineTest.Services.DTO;
using OnlineTest.Services.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository; 
        }

        public bool AddUser(UserDTO user)
        {
            return _userRepository.AddUser(new User{IsActive=user.IsActive, Email = user.Email, MobileNo = user.MobileNo, Name = user.Name, Password = user.Password });
        }
        public bool UpdateUser(UserDTO user)
        {
            return _userRepository.UpdateUser(new User {Id=user.Id, IsActive= user.IsActive,Email= user.Email,MobileNo=user.MobileNo,Name=user.Name,Password=user.Password});
        }
        public bool DeleteUser(int Id)
        {
            return _userRepository.DeleteUser(Id);
        }
        public List<UserDTO> GetUsers()
        {
            try
            {
                var users = _userRepository.GetUsers().Select(s => new UserDTO()
                {
                    IsActive= s.IsActive,
                    Name = s.Name,
                    Email = s.Email,
                    MobileNo = s.MobileNo,
                    Password = s.Password,
                    Id = s.Id
                }).ToList();
                return users;
            }
            catch (Exception ex) 
            {
                throw ex ;
            }
        }
       
       
    }
}

