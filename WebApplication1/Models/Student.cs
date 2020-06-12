using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Student
    {
		public int StudentId { get; set; }
        [Display(Name = "Name")]
        public string StudentName { get; set; }
        public int Age { get; set; }
        public string EmailAddress { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
	}
}