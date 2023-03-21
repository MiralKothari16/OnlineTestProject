using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(30)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email address is Invalid.")]
        [MaxLength(30)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile No is required.")]
        [MaxLength(12)]
        public string MobileNo { get; set; }
        
        public bool IsActive { get; set; }
    }
}
