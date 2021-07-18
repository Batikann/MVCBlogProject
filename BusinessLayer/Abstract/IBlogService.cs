using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService
    {
        List<Blog> GetList();
        void Add(Blog entity);
        Blog GetById(int id);
        void DeleteBlog(int id);
        void Update(Blog entity);
        List<Blog> BlogByID(int id);
        List<Blog> GetBlogByAuthor(int id);
        List<Blog> GetBlogByCategory(int id);
        List<Blog> GetByAuthorMail(int id);

    }
}
