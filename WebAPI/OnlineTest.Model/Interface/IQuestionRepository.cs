using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Model.Interface
{
    public interface IQuestionRepository
    {
        IEnumerable<Questions> GetQuestions();
        bool AddQuestions(Questions question);
        bool UpdateQuestions(Questions question);
        Questions GetQuestionById(int id);
        IEnumerable<Questions> GetQuestionByTestId(int testId);
        IEnumerable<Questions> Paginnation(int page, int content);
    }
}
