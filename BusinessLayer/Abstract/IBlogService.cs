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
        void Delete(Blog entity);
        void Update(Blog entity);
        List<Blog> BlogByID(int id);

    }
}
