using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.helper
{
    public class Yearvalidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Convert.ToInt32(value) <= 2022)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("your hire date should be less current date");
            }
        }
    }
}

