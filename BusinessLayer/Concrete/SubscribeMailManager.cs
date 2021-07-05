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
    public class SubscribeMailManager : ISubscribeMailService
    {
        ISubscribeMailDal _subscribeMailDal;
        public SubscribeMailManager(ISubscribeMailDal subscribeMailDal)
        {
            _subscribeMailDal = subscribeMailDal;
        }
        public void Add(SubscribeMail subscribeMail)
        {
            _subscribeMailDal.Add(subscribeMail);
        }
    }
}
