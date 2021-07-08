using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        List<Comment> GetAllComment();
        List<Comment> GetCommentByBlogId(int id);
        void CommentAdd(Comment comment);
    }
}
