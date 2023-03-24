namespace OnlineTest.Services.DTO
{
    public class AnswerSheetDTO
    {
        public Guid Token { get; set; }
        public List<Answer> Answers { get; set; }

        public class Answer
        {
            public int QuestionId { get; set; }
            public int AnswerId { get; set; }
        }
    }
}
