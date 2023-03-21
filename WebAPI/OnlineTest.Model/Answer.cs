using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Model
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage ="Answer is required.")]
        [MaxLength (100)]
        public string Answers { get; set; }
        public bool Active { get; set; }

        public int CreatedBy { get; set; }
        [Column (TypeName = "DateTime")]
        public DateTime CreatedOn { get; set;}
       
    }
}
