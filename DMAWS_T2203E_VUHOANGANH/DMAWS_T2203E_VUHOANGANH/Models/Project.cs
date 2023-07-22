using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DMAWS_T2203E_VUHOANGANH.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Project Name is required.")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Project Name must be between 2 and 150 characters.")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "Project Start Date is required.")]
        public DateTime ProjectStartDate { get; set; }

        public DateTime? ProjectEndDate { get; set; }

        public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; }
    }
}
