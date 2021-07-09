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
    public class AuthorManager : IAuthorService
    {
        IAdminDal _adminDal;

        public AuthorManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public List<Admin> GetAuthorList()
        {
            return _adminDal.List();
        }
    }
}
