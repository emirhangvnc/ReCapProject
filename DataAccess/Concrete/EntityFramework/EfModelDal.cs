﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
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
                             on m.Brand_Id equals b.Brand_Id

                             join c in context.Colors
                             on m.Color_Id equals c.Color_Id

                             join d in context.CarTypeDetails
                             on m.CarTypeDetail_Id equals d.CarTypeDetail_Id

                             join cat in context.Categories
                             on d.Category_Id equals cat.Category_Id

                             select new ModelDetailDto
                             {
                                 ModelId = m.Model_Id,
                                 ModelName=m.Model_Name,
                                 BrandName = b.Brand_Name,
                                 ColorName = c.Color_Name,
                                 CategoryName = cat.Category_Name,
                                 DailyPrice = (decimal)m.Daily_Price,
                                 ImagePath= (from i in context.CarImages where i.CarId==m.Model_Id select i.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }
    }
}
