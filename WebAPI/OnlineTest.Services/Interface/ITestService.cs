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
    public interface ITestService
    {
        ResponseDTO GetTest();

        ResponseDTO AddTest(AddTestDTO testDTO);
        ResponseDTO UpdateTest(UpdateTestDTO testDTO);

        ResponseDTO GetTestByTechnologyId(int technologyId);
        ResponseDTO GetTestById(int id);
        //bool DeleteTest(int Id);

        //List<TestDTO> Search(int Id, string TestName, int CreatedBy, DateTime createdon, DateTime expireon, string techname);
        ResponseDTO TestPagination(int Page, int Count);
        
        //Addmethod of  Testemaillinks 
        ResponseDTO AddTestEmail(int adminid, int testid, string useremail);
    }
}
