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
    public class FeatureManager : IGenericService<Feature> //Burada "iki nokta(":")'dan sonra direkt olarak IFeatureService yazılarak da implementasyon işlemi uygulanabilir.İki türlü de aynı sonuç alınacaktır. Tüm generate interface'ler için bu durum geçerlidir.
    {
        IFeatureDal  _featureDal;

        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public List<Feature> TGetList()
        {
            return _featureDal.GetList();
        }

        public void TAdd(Feature t)
        {
            _featureDal.Insert(t);
        }

        public void TDelete(Feature t)
        {
            _featureDal.Delete(t);
        }

        public Feature TGetById(int id)
        {
           return _featureDal.GetByID(id);
        }

        public void TUpdate(Feature t)
        {
            _featureDal.Update(t);  
        }
    }
}
