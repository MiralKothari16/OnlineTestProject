using Azure;
using OnlineTest.Model;
using OnlineTest.Model.Interface;
using OnlineTest.Services.DTO;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.UpdateDTO;
using OnlineTest.Services.DTO.GetDTO;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace OnlineTest.Services.Services
{
    public class UserService : IUserService
    {
        #region fields

        private readonly IHasherService _hasherService;
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userroleRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Contr
        public UserService(IUserRepository userRepository, IMapper mapper, IHasherService hasherService, IUserRoleRepository userroleRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _hasherService = hasherService;
            _userroleRepository = userroleRepository;
        }
        #endregion

        #region Methods

        public ResponseDTO GetUsers()
        {
            var response = new ResponseDTO();
            try
            {

                var users = _mapper.Map<List<GetUserDTO>>(_userRepository.GetUsers().ToList());
                response.Status = 200;
                response.Data = users;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                response.Status = 500;
                response.Message = "Internal Server Error.";
                response.Error = ex.Message;
            }
            return response;
        }

        public ResponseDTO UserPagination(int pageno, int content)
        {
            var response = new ResponseDTO();
            try
            {
                var users = _mapper.Map<List<GetUserDTO>>(_userRepository.UserPagination(pageno, content).ToList());
                if (users.Count > 0)
                {
                    response.Status = 200;
                    response.Data = users;
                    response.Message = "OK";
                }
                //else
                //{
                //    response.Status = 404;
                //    response.Message = "No data found.";
                //    response.Error = "No content found for this page.";
                //}
            }
            catch (Exception ex)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = ex.Message;
            }
            return response;
        }

        public ResponseDTO AddUser(AddUserDTO user)
        {
            var response = new ResponseDTO();
            try
            {
                var resultEmail = _userRepository.GetUserByEmail(user.Email);
                if (resultEmail != null)
                {
                    response.Status = 400;
                    response.Message = "Bad Request";
                    response.Error = "Email already exist.";
                    return response;
                }
                user.Password = _hasherService.Hash(user.Password);
                user.IsActive = true;
                var adduser = _userRepository.AddUser(_mapper.Map<User>(user));
                if (adduser > 0)
                {
                    if (user.IsAdmin)
                    {
                        var role = new UserRole
                        {
                            UserId = adduser,
                            RoleId = 1
                        };
                        _userroleRepository.AddUserRole(role);
                    }
                    else
                    {
                        var role = new UserRole
                        {
                            UserId = adduser,
                            RoleId = 2
                        };
                        _userroleRepository.AddUserRole(role);
                    }
                    response.Status = 204;
                    response.Message = "User Created";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Bad Request";
                    response.Error = "User is not Created.";
                }
            }
            catch (Exception ex)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = ex.Message;
            }
            return response;
        }
        public ResponseDTO UpdateUser(UpdateUserDTO user)
        {
            var response = new ResponseDTO();
            try
            {
                var resultId = _userRepository.GetUserById(user.Id);
                if (resultId == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found.";
                    response.Error = "User not found.";
                    return response;
                }
                var resultEmail = _userRepository.GetUserByEmail(user.Email);
                if (resultEmail != null && resultEmail.Id != user.Id)
                {
                    response.Status = 400;
                    response.Message = "Not Created.";
                    response.Error = "User with this email already exist.";
                    return response;
                }
                var updateUser = _userRepository.UpdateUser(_mapper.Map<User>(user));

                if (UpdateUser != null)
                {
                    response.Status = 204;
                    response.Message = "User Updated Successfully.";
                    return response;
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Updated.";
                    response.Error = "User is not updated.";
                }
            }
            catch (Exception ex)
            {
                response.Status = 500;
                response.Message = "Internal server error.";
                response.Error = ex.Message;
            }
            return response;
        }

        public ResponseDTO DeleteUser(int Id)
        {
            var response = new ResponseDTO();
            try
            {
                var userById = _userRepository.GetUserById(Id);
                if (userById == null)
                {
                    response.Status = 404;
                    response.Message = "Not found";
                    response.Error = "User not found.";
                    return response;
                }
                userById.IsActive = false;
                var deleteFlag = _userRepository.DeleteUser(userById);
                if (deleteFlag)
                {
                    response.Status = 200;
                    response.Message = "Deleted Successfully";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "User Not created";
                    response.Error = "User Not Deleted";
                }
            }
            catch (Exception ex)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = ex.Message;
            }
            return response;
        }

        public ResponseDTO GetUserById(int Id)
        {
            var response = new ResponseDTO();
            try
            {
                var resultUserId = _userRepository.GetUserById(Id);
                if (resultUserId == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "User not Found.";
                    return response;
                }
                else
                {
                    var result = _mapper.Map<GetUserDTO>(resultUserId);
                    response.Status = 200;
                    response.Data = result; ;
                    response.Message = "Ok";
                }
            }
            catch (Exception ex)
            {
                response.Status = 500;
                response.Message = "Internal server error";
                response.Error = ex.Message;
            }
            return response;
        }
        public ResponseDTO GetUserByEmail(string Email)
        {
            var response = new ResponseDTO();
            try
            {
                var resultemail = _userRepository.GetUserByEmail(Email);
                if (resultemail == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found.";
                    response.Error = "User not found.";
                    return response;
                }
                else
                {
                    var result = _mapper.Map<GetUserDTO>(resultemail);
                    response.Status = 200;
                    response.Data = result;
                    response.Message = "Ok";
                }
            }
            catch (Exception ex)
            {
                response.Status = 500;
                response.Message = "Internal server error.";
                response.Error = ex.Message;
            }
            return response;
        }

        public GetUserDTO IsUserExists(TokenDTO model)
        {
            //var user = _userRepository.GetUserByEmail(model.Email);
            var user = _userRepository.GetUsers().FirstOrDefault(x => x.Email.ToLower() == model.Username.ToLower());// && x.Password == model.Password);
            if (user == null || user.Password != _hasherService.Hash(model.Password))
            {
                return null;
                //throw new Exception("User not found");
            }
            else { }
            return _mapper.Map<GetUserDTO>(user);
        }
        #endregion
    }
}
