using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Entities.DTOs.CustomerDto;
using DataAccess.Abstract;
using Entities.Concrete;
using AutoMapper;
using Entities.DTOs;
using System.Linq;
using System.Collections.Generic;
using Business.ValidationRules.FluentValidation.CustomerValidator;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        IMapper _mapper;
        public CustomerManager(ICustomerDal customerDal,IMapper mapper)
        {
            _customerDal = customerDal;
            _mapper = mapper;
        }

        #region Void işlemleri

        [ValidationAspect(typeof(CustomerAddDtoValidator))]
        public IResult Add(CustomerAddDto customerAddDto)
        {
            var result = _customerDal.Get(m => m.UserId == customerAddDto.UserId);
            if (result!=null)           
                return new ErrorResult("Böyle Bir Müşteri Zaten Mevcut");

            var customer = _mapper.Map<Customer>(customerAddDto);
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        [ValidationAspect(typeof(CustomerDeleteDtoValidator))]
        public IResult Delete(CustomerDeleteDto customerDeleteDto)
        {
            var result = _customerDal.GetAll().SingleOrDefault(m => m.CustomerId == customerDeleteDto.Id);
            if (result != null)
            {
                _customerDal.Delete(result);
                return new SuccessResult(Messages.CustomerDeleted);
            }
            return new ErrorResult("Silinecek Veri Bulunamadı");
        }

        [ValidationAspect(typeof(CustomerUpdateDtoValidator))]
        public IResult Update(CustomerUpdateDto customerUpdateDto)
        {
            var result = _customerDal.Get(m => m.CustomerId == customerUpdateDto.Id);
            if (result == null)
            {
                return new ErrorResult("Bu Veride Bir Müşteri Yok");
            }
            var customer = _mapper.Map(customerUpdateDto,result);
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
        #endregion

        public IDataResult<List<Customer>> GetAll()
        {          
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Messages.CustomerListed);
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails());
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c=>c.CustomerId==customerId));
        }
    }
}
