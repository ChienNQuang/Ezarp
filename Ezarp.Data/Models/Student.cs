using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ezarp.Data.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Grade Grade { get; set; }
        [Display(Name = "Average")]
        [Range(0, 10)]
        [Required]
        public double AverageGrade { get; set; }
    }
}