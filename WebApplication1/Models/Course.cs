using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Course
    {
        [Key]
        public int CoursesId { get; set; }
        [Display(Name = "Name")]
        public string CoursesName { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}