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

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public void Add(Blog entity)
        {
            throw new NotImplementedException();
        }

        public List<Blog> BlogByID(int id)
        {
            return _blogDal.List(x => x.BlogID == id);
        }

        public void Delete(Blog entity)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetBlogByAuthor(int id)
        {
            return _blogDal.List(x => x.AdminID == id);
        }

        public List<Blog> GetBlogByCategory(int id)
        {
            return _blogDal.List(x => x.CategoryID == id);
        }

        public Blog GetById(int id)
        {
            return _blogDal.Get(x=>x.BlogID==id);
        }

        public List<Blog> GetList()
        {
            return _blogDal.List();
        }

        public void Update(Blog entity)
        {
            throw new NotImplementedException();
        }
    }
}
