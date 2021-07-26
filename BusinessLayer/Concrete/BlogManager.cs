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
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;
        IAdminDal _adminDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public void Add(Blog entity)
        {
            _blogDal.Add(entity);
        }

        public List<Blog> BlogByID(int id)
        {
            return _blogDal.List(x => x.BlogID == id);
        }

        public void DeleteAdminBlog(Blog blog)
        {
            var blogg = _blogDal.Get(x => x.BlogID == blog.BlogID);
            if (blog.BlogStatus == false)
            {
                blog.BlogStatus = true;
                _blogDal.Update(blog);
            }
            else
            {
                blog.BlogStatus = false;
                _blogDal.Update(blog);
            }

        }

        public void DeleteBlog(int id)
        {
            _blogDal.Get(x => x.BlogID == id);
        }

        public List<Blog> GetBlogByAuthor(int id)
        {
            return _blogDal.List(x => x.AdminID == id);
        }

        public List<Blog> GetBlogByCategory(int id)
        {
            return _blogDal.List(x => x.CategoryID == id);
        }

        public List<Blog> GetByAuthorMail(int id)
        {
            return _blogDal.List(x => x.AdminID == id);
        }


        public Blog GetById(int id)
        {
            return _blogDal.Get(x => x.BlogID == id);
        }

        public List<Blog> GetList()
        {
            return _blogDal.List();
        }

        public void Update(Blog entity)
        {
            _blogDal.Update(entity);
        }
    }
}
