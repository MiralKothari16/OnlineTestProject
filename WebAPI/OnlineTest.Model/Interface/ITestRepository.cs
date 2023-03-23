using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Model.Interface
{
    public interface ITestRepository
    {
        IEnumerable<Test> GetTest();
        int AddTest(Test test);
        
        bool UpdateTest(Test test);

        Test GetTestById(int Id);
        IEnumerable<Test> GetTestByTechnologyId(int TechnologyId);

        bool DeleteTest(int Id);

        IEnumerable<Test> TestPagination(int page, int content);
        //IEnumerable<Test> Search(int Id, string TestName,int CreatedBy, DateTime createdon, DateTime expireon,string techname );
    }
}
