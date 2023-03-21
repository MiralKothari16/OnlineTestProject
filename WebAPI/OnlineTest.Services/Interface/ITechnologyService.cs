using OnlineTest.Services.DTO;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.UpdateDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.Interface
{
    public interface ITechnologyService
    {
        ResponseDTO GetTechnology();
        ResponseDTO AddTechnology(AddTechnologyDTO technology);
        ResponseDTO UpdateTechnology(UpdateTechnologyDTO technology);
        //ResponseDTO DeleteTechnology(int Id);
        ResponseDTO TechPagination(int page, int content);
        ResponseDTO GetTechnologyById(int Id);
        ResponseDTO GetTechnologyByName(string Name);
       
        // List<TechnologyDTO> Search(int id, string techname, int createdby, DateTime createdon, int modifiedby, DateTime modifiedon);



    }
}
