using OnlineTest.Model;
using OnlineTest.Services.DTO.GetDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.DTO.AddDTO
{
    public class AddAnswersheetDTO
    {
        //public int Id { get;set; }
        //public Guid Toket { get; set; } 
        //public int QuestionId { get; set; }
        //public int AnswerId { get; set; }
        //public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public Guid Token { get; set; }
        public List<Question> Questions { get; set; }

        public class Question
        {
           public int QuestionId { get; set; }
            public List<int> Answers { get; set; }
        }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
