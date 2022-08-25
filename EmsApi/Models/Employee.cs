using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System;

namespace EmsApi.Models
{
    public class Employee : IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        [Range(100000000000, 999999999999, ErrorMessage = "Mobile no should be 10 digit")]
        public long MobileNo { get; set; }
        [Required]
        public string Email { get; set; }
        [Range(1, double.MaxValue)]
        public double Salary { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateOfBirth >= DateTime.Today)
            {
                yield return new ValidationResult("Date of birth should be in the past",
                    new string[] { nameof(DateOfBirth) });
            }
        }
    }
}
