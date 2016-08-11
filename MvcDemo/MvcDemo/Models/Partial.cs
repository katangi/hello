using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDemo.Models
{
    public partial class Partial
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    }
    public partial class Partial
    {
        public List<Partial> partialModel { get; set; }
      
    }
}