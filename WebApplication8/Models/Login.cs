using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class Login
    {
        [Required(ErrorMessage = "please enter your email")]
        [Display(Name = "Email Address")]
        
        public string Email { get; set; }

        [Required(ErrorMessage = "please enter your password")]
        [Display(Name = "Password")]
        
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
}
