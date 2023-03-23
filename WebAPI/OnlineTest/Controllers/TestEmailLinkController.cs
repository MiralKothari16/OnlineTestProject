using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.Interface;
using OnlineTest.Services.Services;

namespace OnlineTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestEmailLinkController : ControllerBase
    {
        private readonly ITestEmailLinkService _testEmailLinksService;

        public TestEmailLinkController(ITestEmailLinkService testEmailLinksService)
        {
            _testEmailLinksService = testEmailLinksService;
        }
        //[HttpPost]
        //public IActionResult AddTestEmail(AddTestEmailLinkDTO testemsil)
        //{
        //    return Ok(_testEmailLinksService.AddTestEmail(testemsil));
        //}
    }
}
