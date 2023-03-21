using OnlineTest.Model;
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
    public  interface IAnswerService 
    {
        ResponseDTO GetAnswer();
        ResponseDTO GetAnswerById(int id);
        ResponseDTO AddAnswer(AddAnswerDTO answer);

        ResponseDTO UpdateAnswer(UpdateAnswerDTO answer);

        ResponseDTO Pagination(int page, int content);

    }
}
