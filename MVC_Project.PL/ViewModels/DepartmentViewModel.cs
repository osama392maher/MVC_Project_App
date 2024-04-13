using MVC_Project.DAL.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace MVC_Project.PL.ViewModels
{
    public class DepartmentViewModel
    {
        [Required(ErrorMessage = "Code Is Required !!")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Name Is Required !!")]
        public string Name { get; set; }

        [Display(Name = "Date of Creation")]
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>(); // Navigation Property
    }

}



