using OnlineTest.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.DTO.AddDTO
{
    public class AddTechnologyDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Technology is required.")]
        [MaxLength(30,ErrorMessage ="Technology name should by {1} characters long.")]
        public string TechName { get; set; }

        //[ForeignKey("UserCreatedBy")]
        public int CreatedBy { get; set; }
        //[Column(TypeName = "DateTime")]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public bool Active { get; set; } = true;
        //[ForeignKey("UserModifiedBy")]
        
    }
}
