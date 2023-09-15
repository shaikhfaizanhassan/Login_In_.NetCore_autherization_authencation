﻿using System.ComponentModel.DataAnnotations;

namespace RoleBaseAuthen_Autroziation.Models
{
    public class Register
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
