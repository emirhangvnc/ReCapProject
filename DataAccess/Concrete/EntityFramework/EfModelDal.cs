using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
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
                             on m.CarType_Id equals d.Detail_Id

                             join cat in context.Categories
                             on d.Category_Id equals cat.Category_Id

                             select new ModelDetailDto
                             {
                                 ModelId = m.Model_Id,
                                 ModelName=m.Model_Name,
                                 BrandName = b.Brand_Name,
                                 ColorName = c.Color_Name,
                                 CategoryName = cat.Category_Name,
                                 DailyPrice = m.Daily_Price,
                             };
                return result.ToList();
            }
        }
    }
}
