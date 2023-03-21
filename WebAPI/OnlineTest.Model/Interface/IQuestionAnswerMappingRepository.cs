using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Model.Interface
{
    public interface IQuestionAnswerMappingRepository
    {
      //  IEnumerable<QuestionAnswerMapping> GetAnswerMappings
       
        int AddQAMapping(QuestionAnswerMapping questionanswerMapping);
      //  bool UpdateQAMapping(IQuestionAnswerMappingRepository questionAnswerMappingRepository);
       // bool DeleteQAMapping(QuestionAnswerMapping questionanswerMapping);
    }
}
