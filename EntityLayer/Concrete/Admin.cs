﻿using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin:IEntity
    {
        [Key]
        public int AdminID { get; set; }
        public string UserName { get; set; }
        public string AdminMail { get; set; }
        public string AdminImage { get; set; }
        public string AdminAbout { get; set; }
        public string Password { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}