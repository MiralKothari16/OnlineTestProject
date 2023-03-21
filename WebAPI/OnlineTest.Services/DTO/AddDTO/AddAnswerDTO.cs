using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.DTO.AddDTO
{
    public class AddAnswerDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Answer is required.")]
       // [MaxLength(100, ErrorMessage ="Answer can be {1} characters long.")]
        public string Answers { get; set; }
        public bool Active { get; set; } = true;
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public int TestId { get; set; }
        public int QuestionId { get; set; }
    }
}
