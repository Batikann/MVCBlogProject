using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void CommentAdd(Comment comment)
        {
            _commentDal.Add(comment);
        }

        public List<Comment> GetAllComment()
        {
            return _commentDal.List();
        }

        public List<Comment> GetCommentByBlogId(int id)
        {
            return _commentDal.List(x => x.BlogID == id && x.CommentStatus==true);
        }

        public Comment GetCommentById(int id)
        {
            return _commentDal.Get(x=>x.CommentID==id);
        }

        public List<Comment> GetCommentStatusFalse()
        {
            return _commentDal.List(x => x.CommentStatus==false);
        }

        public List<Comment> GetCommentStatusTrue()
        {
            return _commentDal.List(x => x.CommentStatus == true);
        }

        public void CommentChangeStatusFalse(Comment comment)
        {
            comment.CommentStatus = false;
            _commentDal.Update(comment);
        }

        public void CommentChangeStatusTrue(Comment comment)
        {
            comment.CommentStatus = true;
            _commentDal.Update(comment);
        }
    }
}
