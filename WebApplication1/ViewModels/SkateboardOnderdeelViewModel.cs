using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class SkateboardOnderdeelViewModel
    {
        public IEnumerable<Skateboard> Skateboards { get; set; }
        public IEnumerable<Onderdeel> Onderdelen { get; set; }
    }
}