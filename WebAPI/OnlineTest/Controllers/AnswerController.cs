using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using OnlineTest.Model.Interface;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.GetDTO;
using OnlineTest.Services.DTO.UpdateDTO;
using OnlineTest.Services.Interface;
using OnlineTest.Services.Services;

namespace OnlineTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }
        //[HttpGet]
        //public ActionResult<GetAnswerDTO> Get()
        //{
        //    return Ok(_answerService.GetAnswer());
        //}
        [HttpGet]
        public ActionResult<GetAnswerDTO> GetAnswer(int page, int content)
        {
            return Ok(_answerService.Pagination(page, content));
        }
        //[HttpGet("AnaswerById")]
        //public ActionResult<GetAnswerDTO> GetAnswerById(int Id)
        //{
        //    return Ok(_answerService.GetAnswerById(Id));   
        //}
        [HttpPost]
        public IActionResult AddAnswer(AddAnswerDTO answer)
        {
            return Ok(_answerService.AddAnswer(answer));
        }
        [HttpPut]
        public IActionResult UpdateAnswer(UpdateAnswerDTO answer)
        {
            return Ok(_answerService.UpdateAnswer(answer));
        }
    }
}
