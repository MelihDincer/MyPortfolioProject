using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    //Ortak metotları burada tanımladık.  Bu interface den kalıtım alınacak. Base interface diyebiliriz.
    public interface IGenericDal<T> where T : class // T ye bir sınıf gönderdik bu sınıf entity den gelen bir değer olacak.
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        List<T> GetList();
        T GetByID(int id);
    }
}
