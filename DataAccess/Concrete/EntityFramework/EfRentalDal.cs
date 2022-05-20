using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
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
                             on r.Model_Id equals m.Model_Id
                             
                             join c in context.Customers
                             on r.Customer_Id equals c.Customer_Id

                             join u in context.Users
                             on c.User_Id equals u.Id

                             join ctd in context.CarTypeDetails
                             on m.CarTypeDetail_Id equals ctd.CarTypeDetail_Id

                             join cat in context.Categories
                             on ctd.Category_Id equals cat.Category_Id

                             join f in context.FuelTypes
                             on ctd.FuelType_Id equals f.FuelType_Id

                             select new RentalDetailDto
                             {
                                 RentalId = r.Rental_Id,
                                 ModelName=m.Model_Name,
                                 ModelYear=m.Model_Year,
                                 CustomerFirstName=u.FirstName,
                                 CustomerLastName=u.LastName,
                                 DailyPrice=m.Daily_Price,
                                 RentDate=r.RentDate,
                                 ReturnDate=r.ReturnDate,
                                 CategoryName=cat.Category_Name,
                                 FuelTypeName=f.FuelType_Name
                             };
                return result.ToList();
            }
        }
    }
}
