using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
    public class AdminLogin:IDto
    {
        public string EmailID { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
