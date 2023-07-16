using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    //Oluşturduğumuz interface lerde ortak imzalar olduğundan ve tek farkın metot parametreleri olduğundan dolayı Generic bir interface oluşturma ihtiyacı duyduk. T adında bir değer belirledik ve bu T değeri bir class olacak, bu class Generic interface i miras alan interface'de belirlenecek. 
    public interface IGenericDal<T> where T : class // T ye bir sınıf gönderdik bu sınıf entity den gelen bir değer olacak.
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        List<T> GetList();
        T GetByID(int id);
    }
}