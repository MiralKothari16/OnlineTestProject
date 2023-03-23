using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.GetDTO;
using OnlineTest.Services.DTO.UpdateDTO;
using OnlineTest.Services.Interface;
using OnlineTest.Services.Services;

namespace OnlineTest.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyController : ControllerBase
    {
        private readonly ITechnologyService _technologyServices;
        
        public TechnologyController(ITechnologyService technologyService)
        {
            _technologyServices = technologyService;
        }
        //[HttpGet]
        //public ActionResult<TechnologyDTO> Get() 
        //{
        //    return Ok(_technologyServices.GetTechnology());
        //}
        [HttpGet("Paging")]
        public ActionResult<GetTechnologyDTO> GetTechnology(int page,int content)
        {
            return Ok(_technologyServices.TechPagination(page, content));
        }
        //[HttpGet("GeTechById")]
        //public ActionResult<TechnologyDTO> GetTechnologyById(int Id)
        //{
        //    return Ok(_technologyServices.GetTechnologyById(Id));
        //}
        [HttpPost]
        public IActionResult AddTechnology(AddTechnologyDTO technology)
        {
            return Ok(_technologyServices.AddTechnology(technology));
        }
        [HttpPut]  
        public IActionResult UpdateTechnology(UpdateTechnologyDTO technology)
        {
            return Ok(_technologyServices.UpdateTechnology(technology));
        }
      
    }
}
