using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Model
{
    public class Test
    {
        [Key]
        public int Id { get; set; }
        
        [Required (ErrorMessage ="TestName is required.")]
        [MaxLength(20)]
        public string TestName { get; set; }
        [MaxLength(100)]
       
        public string Description { get; set; }
       
        [ForeignKey("UserCreatedBy")]
        public int CreatedBy { get; set; }
        
        [Column (TypeName = "DateTime")]
        public DateTime CreatedOn { get; set; }

        [Column (TypeName ="DateTime")]
        public DateTime? ExpireOn { get; set; }
       
        public int TechnologyId { get; set; }

        public bool Active { get; set; }
        
        public virtual User UserCreatedBy { get; set; }
        
        public virtual Technology Technology { get; set; }
    }
}
