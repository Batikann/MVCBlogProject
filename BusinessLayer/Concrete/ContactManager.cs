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
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;
        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void AddContact(Contact contact)
        {
            _contactDal.Add(contact);
        }

        public List<Contact> GetContact()
        {
            return _contactDal.List();
        }

        public Contact GetContactByID(int id)
        {
           return _contactDal.Get(x => x.ContactID == id);
        }
    }
}
