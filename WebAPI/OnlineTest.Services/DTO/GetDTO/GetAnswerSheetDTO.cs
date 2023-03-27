using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.DTO.GetDTO
{
    public  class GetAnswerSheetDTO
    {
        public int Id { get; set; }

        public Guid Token { get; set; }

        public List<GetQuestionDTO>? Questions { get; set; }

        public List<GetAnswerDTO> Answers { get; set; }
    }
}
