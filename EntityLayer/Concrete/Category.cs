using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category:IEntity
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}
