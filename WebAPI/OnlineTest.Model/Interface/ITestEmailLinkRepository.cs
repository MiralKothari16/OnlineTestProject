using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Model.Interface
{
    public interface ITestEmailLinkRepository
    {
        int AddTestEmail(TestEmailLink testEmailLink);
        bool IsLinkExist(int TestId,int UserId);
    }
}
