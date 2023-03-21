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
    public class AddTestDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Test Name is required.")]
        [MaxLength(20, ErrorMessage ="Test Name should be{1}characters long.")]
        public string TestName { get; set; }
        [MaxLength(100, ErrorMessage = "Test Description should be {1} characters long.")]
        public string Description { get; set; }
        //[ForeignKey("UserCreatedBy")]
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? ExpireOn { get; set; }
        public bool Active { get; set; } = true;
        public int TechnologyId { get; set; }
    }
}
