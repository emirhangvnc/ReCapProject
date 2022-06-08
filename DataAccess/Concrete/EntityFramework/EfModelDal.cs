using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs.ModelDto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfModelDal : EfEntityRepositoryBase<Model, RentalCarContext>, IModelDal
    {
        public List<ModelDetailDto> GetModelDetails(Expression<Func<ModelDetailDto,bool>> filter=null)
        {
            using (RentalCarContext context = new RentalCarContext())
            {
                //ImagePath= (from i in context.CarImages where i.CarId==m.ModelId select i.ImagePath).FirstOrDefault()

                var result = from m in context.Models
                             join b in context.Brands
                             on m.ModelId equals b.BrandId
                             join co in context.Colors
                             on m.ModelId equals co.ColorId

                             select new ModelDetailDto
                             {
                                 ModelId = m.ModelId,
                                 ModelName = m.ModelName,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 ModelYear = m.ModelYear,
                                 DailyPrice = m.DailyPrice,
                                 ImagePath=(from i in context.CarImages where i.CarId==m.ModelId select i.ImagePath).ToList()
                             };
                return filter == null ?
                    result.ToList() :
                    result.Where(filter).ToList();
            }
        }
    }
}
