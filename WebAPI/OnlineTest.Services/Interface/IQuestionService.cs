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
    public interface IQuestionService
    {
        ResponseDTO GetQuestions();

        ResponseDTO GetQuestionById(int id);
        ResponseDTO AddQuestions(AddQuestionDTO question);

        ResponseDTO UpdateQuestions(UpdateQuestionDTO question);
        ResponseDTO Pagination(int page, int content);
    }
}
