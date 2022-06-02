using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs.ModelDto;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfModelDal : EfEntityRepositoryBase<Model, RentalCarContext>, IModelDal
    {
        public List<ModelDetailDto> GetModelDetails()
        {
            using (RentalCarContext context = new RentalCarContext())
            {
                var result = from m in context.Models
                             join b in context.Brands
                             on m.BrandId equals b.BrandId

                             join c in context.Colors
                             on m.ColorId equals c.ColorId

                             join d in context.CarTypeDetails
                             on m.CarTypeDetailId equals d.CarTypeDetailId

                             join cat in context.Categories
                             on d.CategoryId equals cat.CategoryId

                             select new ModelDetailDto
                             {
                                 ModelId = m.ModelId,
                                 ModelName=m.ModelName,
                                 BrandName = b.BrandName,
                                 ColorName = c.ColorName,
                                 CategoryName = cat.CategoryName,
                                 DailyPrice = (decimal)m.DailyPrice,
                                 ImagePath= (from i in context.CarImages where i.CarId==m.ModelId select i.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }
    }
}
