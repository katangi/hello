using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDemo.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string password { get; set; }
        public string Email { get; set; }
    }
}