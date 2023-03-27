using OnlineTest.Model;
using OnlineTest.Services.DTO.GetDTO;

namespace OnlineTest.Services.DTO
{
    public class AnswerSheetDTO
    {
        public Guid Token { get; set; }
        public List<Questions> Question { get; set; }

        public class Answer
        {
            public List<GetQuestionDTO>? QuestionId { get; set; }
            //public int QuestionId { get; set; }
            public List<GetAnswerDTO> Answers { get; set; }
            // public int AnswerId { get; set; }
        }
    }
}
//// Added for learning in a single dto.