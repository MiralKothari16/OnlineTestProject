using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.DTO.UpdateDTO
{
    public class UpdateAnswerDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Answer is required.")]
        // [MaxLength(100, ErrorMessage ="Answer can be {1} characters long.")]
        public string Answers { get; set; }
    }
}
