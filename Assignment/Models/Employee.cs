using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        [Required]
        public long Contact { get; set; }
        [Required]
        [Display(Name = "Role Id")]
        public int RoleId { get; set; }

    }
}