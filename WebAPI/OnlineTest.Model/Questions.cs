using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Model
{
    public class Questions
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Question is required.")]
        [MaxLength(50)]
        public string QuestionName { get; set; }

        [Required(ErrorMessage ="Que is required")]
        public string Que { get; set; }
        
        public int Type { get; set; }
        [ForeignKey ("test_Id")]
        public int TestId { get; set; }
        
        public int SortOrder { get; set; }
        
        public int Weightage { get; set; }
        [DefaultValue(true)]
        public bool Active { get; set; }
        public int CreateBy { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime CreateOn { get; set; }
        public Test test_Id { get; set; }

    }
}
