using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class SignIn
    {
        [Required(ErrorMessage = "please enter your First Name")]
        [Display(Name = "First Name")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "please enter your Last Name")]
        [Display(Name = "Last Name")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }


        [Required (ErrorMessage ="please enter your email")]
        [Display (Name ="Email Address")]
        [EmailAddress(ErrorMessage ="please enter vaild email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "please enter your strong password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage="Password doesnt match")]
        public string Password { get; set; }

        [Required(ErrorMessage = "please confirm your password ")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
