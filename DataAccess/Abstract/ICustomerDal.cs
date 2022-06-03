using Entities.Concrete;
using Core.Entities;
using System.Collections.Generic;
using Entities.DTOs.CustomerDto;

namespace DataAccess.Abstract
{
    public interface ICustomerDal:IEntityRepository<Customer>
    {
        List<CustomerDetailDto> GetCustomerDetails();
    }
}
