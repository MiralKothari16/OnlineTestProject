using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineTest.Services.DTO;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.GetDTO;
using OnlineTest.Services.DTO.UpdateDTO;
using OnlineTest.Services.Interface;

namespace OnlineTest.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        //[HttpGet]
        //public ActionResult<AddQuestionDTO> Get()
        //{
        //    return Ok(_questionService.GetQuesions());
        //}
        [HttpGet]
        public ActionResult<GetQuestionDTO> GetQuestions(int page, int content)
        {
            return Ok(_questionService.Pagination(page, content));
        }

        //[HttpGet("GetQuestionById")]
        //public ActionResult<AddQuestionDTO> GetQuesionsById(int Id)
        //{
        //    return Ok(_questionService.GetQuestionById(Id));
        //}

        [HttpPost]
        public IActionResult AddQuestion(AddQuestionDTO question)
        {
            return Ok(_questionService.AddQuestions(question));
        }
        [HttpPut]
        public IActionResult UpdateQuestion(UpdateQuestionDTO question)
        {
            return Ok(_questionService.UpdateQuestions(question));
        }


    }
}
