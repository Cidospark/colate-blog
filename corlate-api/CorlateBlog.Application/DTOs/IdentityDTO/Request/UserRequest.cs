﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorlateBlog.Application.DTOs.IdentityDTO.Request
{
    public class UserRequest
    {
        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress]
        public string Email { get; set; } = "";

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\\w\\d\\s])([^\\s]){8,16}$", ErrorMessage = "requires at least one lowercase letter, one uppercase letter, one number, one special character, and a total length of 8 to 16 characters")]
        public string Password { get; set; }
    }
}
