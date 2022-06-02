using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.CustomerDto;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<Customer> GetById(int customerId);

        IDataResult<List<Customer>> GetAll();
        IDataResult<List<CustomerDetailDto>> GetCustomerDetails();

        IResult Add(CustomerAddDto customerAddDto);
        IResult Update(CustomerUpdateDto customerUpdateDto);
        IResult Delete(CustomerDeleteDto customerDeleteDto);
    }
}
