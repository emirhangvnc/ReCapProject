using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs.CustomerDto;
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
                             on c.UserId equals u.Id

                             join g in context.Genders
                             on u.GenderId equals g.GenderId
                            
                             select new CustomerDetailDto
                             {
                              Customer_Id=c.CustomerId,
                              CompanyName=c.CompanyName,
                              FirstName=u.FirstName,
                              LastName=u.LastName,
                              GenderName=g.GenderName,
                             };
                 return result.ToList();
            }
        }
    }
}
