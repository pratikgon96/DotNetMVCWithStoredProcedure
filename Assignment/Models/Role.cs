﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class Role
    {
        [Key]
       public int Id { get; set; }
        [Required]
       public string Name { get; set; }
    }
}