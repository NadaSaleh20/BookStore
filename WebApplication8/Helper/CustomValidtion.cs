using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Helper
{
    public class CustomValidtion : ValidationAttribute
    {
        public string  text { get; set; }

       
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {

                string bookName = (string)value;
                if (bookName.Contains(text))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("invalid input type");
        }
    }
}
