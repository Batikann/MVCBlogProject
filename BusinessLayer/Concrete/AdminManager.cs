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
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;
        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }
        public void Add(Admin admin)
        {
            _adminDal.Add(admin);
        }

        public Admin GetAdmin(int id)
        {
            return _adminDal.Get(x => x.AdminID == id);
        }

        public Admin GetAdminByEmail(string email)
        {
            return _adminDal.Get(x => x.AdminMail == email);
        }

        public void Update(Admin admin)
        {
            _adminDal.Update(admin);
        }
    }
}
