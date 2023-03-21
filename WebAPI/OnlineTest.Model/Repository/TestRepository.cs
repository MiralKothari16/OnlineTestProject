using OnlineTest.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Model.Repository
{
    public class TestRepository : ITestRepository
    {
        #region Field
        private readonly OnlineTestContext _context;
        #endregion
        #region Cntr
        public TestRepository(OnlineTestContext context)
        {
            _context = context;
        }
        #endregion
        #region Methods

        public IEnumerable<Test> GetTest()
        {
            return _context.Tests.ToList();
        }
        public bool AddTest(Test test)
        {
            _context.Tests.Add(test);
            return _context.SaveChanges() > 0;
        }
        public bool UpdateTest(Test test)
        {
            _context.Tests.Update(test);
            return _context.SaveChanges() > 0;
        }
        public bool DeleteTest(int Id)
        {
            var del = _context.Tests.Find(Id);
            if (del != null)
            {
                _context.Tests.Remove(del);
            }
            return _context.SaveChanges() > 0;
        }
        public Test GetTestById(int id)
        {
            return _context.Tests.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Test> GetTestByTechnologyId(int technologyId)
        {
            return _context.Tests.Where(t => t.TechnologyId == technologyId && t.Active == true).ToList();
        }

        public IEnumerable<Test> TestPagination(int page, int content)
        {
            return _context.Tests.Skip((page - 1) * content).Take(content).ToList();
        }
        #endregion

    }
}
