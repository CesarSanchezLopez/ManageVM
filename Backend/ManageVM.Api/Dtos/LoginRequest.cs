﻿using System.ComponentModel.DataAnnotations;

namespace ManageVM.Api.Dtos
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
