using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == 1 || customer.MembershipTypeId == 0)
                return ValidationResult.Success;

            if (customer.BirthDate == null)
                return new ValidationResult("Please Enter Date Of Birth");

            int age = DateTime.Now.Year - customer.BirthDate.Value.Year;

            return (age > 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Customer Should be at least 18 Years of Age to be a Member");
            
        }
    }
}