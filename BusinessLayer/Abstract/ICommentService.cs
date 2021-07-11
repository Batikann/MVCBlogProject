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
        Comment GetCommentById(int id);
        List<Comment> GetCommentStatusTrue();
        List<Comment> GetCommentStatusFalse();
        void CommentChangeStatusFalse(Comment comment);
        void CommentChangeStatusTrue(Comment comment);
        void CommentAdd(Comment comment);
    }
}
