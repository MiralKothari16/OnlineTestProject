using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.DTO.AddDTO
{
    public class AddQuestionDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Question is required.")]
        [MaxLength(50)]
        public string QuestionName { get; set; }

        [Required(ErrorMessage = "Que is required")]
        public string Que { get; set; }
        [Required(ErrorMessage = "Type is required")]
        public int Type { get; set; }
        [Required(ErrorMessage = "Test Id is required")]
        public int TestId { get; set; }
        [Required(ErrorMessage = "SortOrder is required")]
        public int SortOrder { get; set; }
        [Required(ErrorMessage = "Weightage is required")]
        public int Weightage { get; set; }
        public bool Active { get; set; } = true;
        public int CreateBy { get; set; }
       // [Column(TypeName = "datetime")]
        public DateTime CreateOn { get; set; }= DateTime.UtcNow;
    }
}
