using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs.RentalDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentalCarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentalCarContext context = new RentalCarContext())
            {
                var result = from r in context.Rentals
                             join m in context.Models
                             on r.ModelId equals m.ModelId
                             
                             join c in context.Customers
                             on r.CustomerId equals c.CustomerId

                             join u in context.Users
                             on c.UserId equals u.Id

                             join ctd in context.CarTypeDetails
                             on m.CarTypeDetailId equals ctd.CarTypeDetailId

                             join cat in context.Categories
                             on ctd.CategoryId equals cat.CategoryId

                             join f in context.FuelTypes
                             on ctd.FuelTypeId equals f.FuelTypeId

                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 ModelName=m.ModelName,
                                 ModelYear=m.ModelYear,
                                 CustomerFirstName=u.FirstName,
                                 CustomerLastName=u.LastName,
                                 DailyPrice=m.DailyPrice,
                                 RentDate=r.RentDate,
                                 ReturnDate=r.ReturnDate,
                                 CategoryName=cat.CategoryName,
                                 FuelTypeName=f.FuelTypeName
                             };
                return result.ToList();
            }
        }
    }
}
