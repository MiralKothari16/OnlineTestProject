using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineTest.Services.DTO;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.GetDTO;
using OnlineTest.Services.DTO.UpdateDTO;
using OnlineTest.Services.Interface;
using OnlineTest.Services.Services;

namespace OnlineTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }
        //[HttpGet("GetTest")]
        //public ActionResult<AddTestDTO> Get() 
        //{
        //    return Ok(_testService.GetTest());
        //}
        [HttpGet]
        public ActionResult<GetTestDTO> GetTest(int page, int content)
        {
            return Ok(_testService.TestPagination(page, content));
        }
        //[HttpGet("TestById")]
        //public ActionResult<AddTestDTO> GettesById(int Id)
        //{
        //    return Ok(_testService.GetTestById(Id));
        //}

        [HttpPost]
        public IActionResult AddTest(AddTestDTO test)
        {
            return Ok(_testService.AddTest(test));
        }
        [HttpPut]
        public IActionResult UpdateTechnology(UpdateTestDTO test)
        {
            return Ok(_testService.UpdateTest(test));
        }
    }
}
