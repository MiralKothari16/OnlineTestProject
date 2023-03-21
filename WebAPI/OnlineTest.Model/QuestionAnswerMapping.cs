using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Model
{
    public class QuestionAnswerMapping
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("question_Id")]
        public int QuestionId { get; set; }
        [ForeignKey("answer_Id")]
        public int AnswerId { get; set;}
        [ForeignKey("test_Id")]
        public int TestId { get; set; }
        public int CreateBy { get; set; }
        [Column (TypeName ="datetime")]
        public DateTime CreatedOn { get; set; }
        public bool Active { get; set; }
        public bool IsAnswer { get; set; }
        public Test test_Id { get; set; }
        public Questions question_Id { get; set; }
        public Answer answer_Id { get; set; }

    }
}
