using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext() : base("name=DbConnStrStudents")
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Skateboard> Skateboards { get; set; }
        public DbSet<Onderdeel> Onderdelen { get; set; }
    }
}