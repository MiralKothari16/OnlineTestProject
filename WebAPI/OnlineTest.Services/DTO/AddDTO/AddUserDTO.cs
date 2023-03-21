﻿using OnlineTest.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.DTO.AddDTO
{
    public class AddUserDTO
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(30, ErrorMessage ="Name can not be longer than {1} characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(30),MinLength(5, ErrorMessage = "Password should be minimum {2} to maximum {1} characters long.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email address is Invalid.")]
        [MaxLength(30,ErrorMessage ="Email address should not be more than {1} characters long.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile No is required.")]
        [RegularExpression("^([0-9]{12})$",ErrorMessage = "Mobile number must contain 12 or less than 12 digits." )]
        [MaxLength(12)]
        public string MobileNo { get; set; }

        public bool IsActive { get; set; } = true;
    }
}