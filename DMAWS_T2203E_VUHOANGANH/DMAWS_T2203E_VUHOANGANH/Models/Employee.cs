using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DMAWS_T2203E_VUHOANGANH.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Employee Name is required.")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Employee Name must be between 2 and 150 characters.")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Employee Date of Birth is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime EmployeeDOB { get; set; }

        [Required(ErrorMessage = "Employee Department is required.")]
        public string EmployeeDepartment { get; set; }

        public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; }
    }
}
