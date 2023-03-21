using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.DTO.UpdateDTO
{
    public class UpdateTestDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Test Name is required.")]
        [MaxLength(20, ErrorMessage = "Test Name should be{1}characters long.")]
        public string TestName { get; set; }
        [MaxLength(100, ErrorMessage = "Test Description should be {1} characters long.")]
        public string Description { get; set; }
        public DateTime? ExpireOn { get; set; }
    }
}
