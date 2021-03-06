using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog:IEntity
    {
        [Key]
        public int BlogID { get; set; }
        public string BlogTitle { get; set; }
        public string BlogImage { get; set; }
        public DateTime BlogDate { get; set; }
        public string BlogContent { get; set; }
        public string BlogPreRead { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public int BlogRating { get; set; }

        public int AdminID { get; set; }
        public virtual Admin Admin { get; set; }
        public bool BlogStatus { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
