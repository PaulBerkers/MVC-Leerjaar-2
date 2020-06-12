using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Onderdeel
    {
        [Key]
        public int OnderdeelId { get; set; }
        [Display(Name = "Name")]
        public string OnderdeelName { get; set; }
        public int OnderdeelQuantity { get; set; }
        public virtual ICollection<Skateboard> Skateboards { get; set; }

    }
}