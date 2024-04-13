﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Project.DAL.Models
{
    public enum Gender
    {
        [EnumMember(Value = "Male")] // This is used to serialize the enum value as string when saved in database
        MALE = 1,
        [EnumMember(Value = "Female")]
        FEMALE = 2
    }

    public enum EmpType
    {
        [EnumMember(Value = "FullTime")]
        FullTime = 1,
        [EnumMember(Value = "PartTime")]
        PartTime = 2,
    }

    public class Employee : ModelBase
    {
        [Required(ErrorMessage = "Name is required")] // Mapped with database
        [MaxLength(50, ErrorMessage = "Name can't be more than 50 characters")] // Mapped with database
        [MinLength(5, ErrorMessage = "Name can't be less than 3 characters")] // Not Mapped with database
        public string Name { get; set; }
        [Range(18, 35)] // Not Mapped with database
        public int? Age { get; set; }
        [RegularExpression(@"^[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{5,10}$",
            ErrorMessage = "Address must be like 123-Street-City-Country")]
        [Required]
        public string Address { get; set; }
        [DataType(DataType.Currency)] // Not Mapped with database (it's decimal(18,2) in database) [The currency is used to view the value as currency]
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        [EmailAddress] // Not Mapped with database, just to take format of email
        [Required]
        public string Email { get; set; }
        [Phone] // Not Mapped with database, just to take format of phone number
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public EmpType EmployeeType { get; set; }
        [Display(Name = "Hire Date")] // Not Mapped with database, just to change the name of the property in front end
        public DateTime HireDate { get; set; }
        [Display(Name = "Creation Date")]
        public int DepartmentId { get; set; } // Foreign Key 
        public virtual Department Department { get; set; } // Navigation Property


    }

}
