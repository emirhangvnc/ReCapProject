using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentalCarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (RentalCarContext context = new RentalCarContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                             on c.User_Id equals u.User_Id

                             join g in context.Genders
                             on u.Gender_Id equals g.Gender_Id
                            
                             select new CustomerDetailDto
                             {
                              Customer_Id=c.Customer_Id,
                              CompanyName=c.Company_Name,
                              FirstName=u.FirstName,
                              LastName=u.LastName,
                              GenderName=g.Gender_Name,
                             };
                return result.ToList();
            }
        }
    }
}
