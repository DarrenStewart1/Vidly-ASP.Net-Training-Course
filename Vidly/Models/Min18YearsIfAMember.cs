using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var customer = (Customer)validationContext.ObjectInstance;

            if(customer.MembershipTypeId == MembershipType.Unknown ||customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;

            }

            if(customer.Dob == null)
            {
                return new ValidationResult("BirthDate is required");
            }

            var age = DateTime.Today.Year - customer.Dob.Year;

            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer should be atleast 18 to get a membership");


         
        }

    }
}