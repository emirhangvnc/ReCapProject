using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IColorDal
    {
        List<Color> GetAll();
        void Add(Color car);
        void Update(Color car);
        void Delete(Color car);
    }
}
