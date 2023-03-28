using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Model
{
    public class Technology
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Technology is required")]
        [MaxLength(30)]
        public string TechName { get; set; }
        
        [ForeignKey("UserCreatedBy")]
        public int CreatedBy { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime CreatedOn { get; set; }
        
        [ForeignKey("UserModifiedBy")]
        public int? ModifiedBy { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime? ModifiedOn { get; set; }

        public bool Active { get; set; }

        public virtual User UserCreatedBy { get; set; }
       
        public virtual User UserModifiedBy { get; set; }

    }
}
