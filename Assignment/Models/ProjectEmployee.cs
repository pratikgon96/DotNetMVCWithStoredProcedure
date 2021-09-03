using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class ProjectEmployee
    {
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        public Project project { get; set; }
        public Employee employee { get; set; }
    }
}