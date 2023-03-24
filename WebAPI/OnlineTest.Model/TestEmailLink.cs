using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Model
{
    public class TestEmailLink
    {
        [Key]
        public int Id { get; set; }
        public Guid Token { get; set; }
        [ForeignKey ("test_Id")]
        public  int TestId { get; set; }
        [ForeignKey ("user_Id")]
        public int UserId { get; set; }  
        public int CreatedBy { get; set; }
        [Column (TypeName ="DateTime")]
        public DateTime CreatedOn    { get; set;}
        [Column (TypeName ="DateTime")]
        public DateTime? AccessedOn { get; set;}
        public int AccessCount { get; set; }
        [Column (TypeName ="DateTime")]
        public DateTime? SubmitOn { get; set; }
        [Column (TypeName="DateTime")]
        public DateTime ExpireOn { get; set;}
        public bool Active { get; set; }

        public virtual Test test_Id { get; set; }
        public virtual User user_Id { get; set; }
    }

}
