using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, RentalCarContext>, ICarImageDal
    {
        public bool IsExist(int id)
        {
            using (RentalCarContext context = new RentalCarContext())
            {
                return context.CarImages.Any(p => p.ImageId == id);
            }
        }
    }
}
