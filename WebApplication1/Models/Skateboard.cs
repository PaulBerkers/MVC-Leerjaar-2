using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class Skateboard
    {
        public int SkateboardId { get; set; }
        [Display(Name = "Name")]
        public string SkateboardBrand { get; set; }
        public string SkateboardWidth { get; set; }
        public string SkateboardCurve { get; set; }
        public virtual ICollection<Onderdeel> Onderdelen { get; set; }
    }
}