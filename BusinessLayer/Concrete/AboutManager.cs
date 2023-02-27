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
    public class AboutManager : IAboutService // Bir interface miras alınıyorsa, o interface nin içerisindeki metodları bu class ın içerisine dahil etmemiz (implamente) gerekmektedir.
    {
        IAboutDal _aboutDal;

        //Constructor oluşturuldu.
        public AboutManager(IAboutDal aboutDal) 
        {
            _aboutDal = aboutDal;
        }

        public List<About> GetList()
        {
            return _aboutDal.GetList();
        }

        public void TAdd(About t)
        {
            _aboutDal.Insert(t);
        }

        public void TDelete(About t)
        {
            _aboutDal.Delete(t);
        }

        public About TGetById(int id)
        {
            return _aboutDal.GetByID(id);
        }

        public void TUpdate(About t)
        {
            _aboutDal.Update(t);
        }
    }
}
