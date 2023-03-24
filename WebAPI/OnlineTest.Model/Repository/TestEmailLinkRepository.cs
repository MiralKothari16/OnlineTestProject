using OnlineTest.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Model.Repository
{
    public class TestEmailLinkRepository : ITestEmailLinkRepository
    {
        #region fileds
        private readonly OnlineTestContext _context;
        #endregion
        #region Constr
        public TestEmailLinkRepository(OnlineTestContext context)
        {
            _context = context;
        }
        #endregion
        #region Methods
        public int AddTestEmailLink(TestEmailLink testEmailLink)
        {
            _context.TestEmailLinks.Add(testEmailLink);
            if (_context.SaveChanges() > 0)
            { return testEmailLink.Id; }
            else { return 0; }
        }

        public TestEmailLink GetTestEmailLink(Guid token)
        {
            return _context.TestEmailLinks.FirstOrDefault(x => x.Token == token && x.ExpireOn > DateTime.UtcNow);
        }
        public bool IsLinkExist(int testId, int userId)
        {
            var result = _context.TestEmailLinks.FirstOrDefault(x => x.TestId == testId && x.UserId == userId && x.ExpireOn > DateTime.UtcNow);
            if (result != null) { return true; }
            else { return false; }
        }

        public bool UpdateTestEmailLink(TestEmailLink testEmailLink)
        {
            _context.Entry(testEmailLink).Property("AccessedOn").IsModified = true;
            return _context.SaveChanges() > 0;
        }

        #endregion
    }
}
