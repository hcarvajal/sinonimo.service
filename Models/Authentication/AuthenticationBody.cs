﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Authentication
{
    public class AuthenticationBody
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? UserName { get;set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get;set; } = null;
    }
}
