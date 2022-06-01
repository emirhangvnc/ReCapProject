using Core.Entities;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICarImageDal : IEntityRepository<CarImage>
    {
        public bool IsExist(int id);
    }
}
