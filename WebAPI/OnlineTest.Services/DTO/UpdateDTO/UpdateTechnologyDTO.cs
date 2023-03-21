using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.DTO.UpdateDTO
{
    public class UpdateTechnologyDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Technology is required.")]
        [MaxLength(30, ErrorMessage = "Technology name should by {1} characters long.")]
        public string TechName { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; } = DateTime.UtcNow;
    }
}
