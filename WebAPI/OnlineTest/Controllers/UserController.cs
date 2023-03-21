using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.GetDTO;
using OnlineTest.Services.DTO.UpdateDTO;
using OnlineTest.Services.Interface;
using System.Diagnostics.Eventing.Reader;
using System.Net;
using System.Runtime.Serialization;

namespace OnlineTest.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        //[HttpGet]
        //public ActionResult<GetUserDTO> Get()
        //{
        //    return Ok(_userService.GetUsers());
        //}
        [HttpGet]
        public ActionResult<GetUserDTO> GetUsers(int page, int content)
        {
            return Ok(_userService.UserPagination(page,content));
         }
        //[HttpGet("UserById")]
        //public ActionResult<GetUserDTO> GetUserById(int Id)
        //{
        //    return Ok(_userService.GetUserById(Id));
        //}
        [HttpPost]
        public IActionResult AddUser(AddUserDTO user)
        {
            return Ok(_userService.AddUser(user));
        }
        [HttpPut]
        public IActionResult UpdateUser(UpdateUserDTO user)
        {
            return Ok(_userService.UpdateUser(user));            
        }
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            return Ok(_userService.DeleteUser(Id));
        }
        ///
    }
}
