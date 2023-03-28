using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Model.Interface
{
    public interface IAnswerSheetRepository
    {
        IEnumerable<AnswerSheet> GetTestAnswers();
        
        bool AddAnswerSheet(List<AnswerSheet> answerSheet);
    }
}
