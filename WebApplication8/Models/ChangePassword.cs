using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class ChangePassword
    {
        [Required , Display( Name ="Enter your Password") ]
        public string Password { get; set; }

        [Required, Display(Name = "Enter your new Password")]
        public string changepassword { get; set; }

        [Required, Display(Name = "Confirm your Password")]
        [Compare("changepassword" , ErrorMessage ="Enter the write password")]
        public string confirmpassword { get; set; }
    }
}
