using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SubscribeMail : IEntity
    {
        [Key]
        public int MailID { get; set; }

        [EmailAddress]
        [RegularExpression(@"^([A-Za-z0-9][^'!&\\#*$%^?<>()+=:;`~\[\]{}|/,₹€@ ][a-zA-z0- 
    9-._][^!&\\#*$%^?<>()+=:;`~\[\]{}|/,₹€@ ]*\@[a-zA-Z0-9][^!&@\\#*$%^?<> 
        ()+=':;~`.\[\]{}|/,₹€ ]*\.[a-zA-Z]{2,6})$")]
        public string Mail { get; set; }
    }
}
