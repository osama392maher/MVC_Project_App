using System;
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
        [Required] // Mapped with database
        [MaxLength(50)] // Mapped with database
        public string Name { get; set; }
        public int? Age { get; set; }
        [Required]
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public EmpType EmployeeType { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }

        public string ImageName { get; set; }

        public int DepartmentId { get; set; } // Foreign Key 
        public virtual Department Department { get; set; } // Navigation Property


    }

}
