using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Entities.DTOs.RentalDto;
using System;
using AutoMapper;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using Business.ValidationRules.FluentValidation.RentalValidator;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        IMapper _mapper;
        public RentalManager(IRentalDal rentalDal, IMapper mapper)
        {
            _rentalDal = rentalDal;
            _mapper = mapper;
        }

        #region Void işlemleri

        //[SecuredOperation("admin,moderator")]
        [ValidationAspect(typeof(RentalAddDtoValidator))]
        public IResult Add(RentalAddDto rentalAddDto)
        {
            var result = _rentalDal.GetAll(r => r.ModelId == rentalAddDto.ModelId);
            if (result != null)
            {
                foreach (var rental in result)
                {
                    if (rental.ReturnDate > DateTime.Now)
                    {
                        return new ErrorResult("Bu Arabanın Kiralık Süresi Dolmamıştır");
                    }
                }
            }
            var newRental = _mapper.Map<Rental>(rentalAddDto);
            _rentalDal.Add(newRental);
            return new SuccessResult(Messages.RentalAdded);
        }

        // [SecuredOperation("admin,moderator")]
        [ValidationAspect(typeof(RentalDeleteDtoValidator))]
        public IResult Delete(RentalDeleteDto rentalDeleteDto)
        {
            var result = _rentalDal.Get(r => r.RentalId == rentalDeleteDto.Id);
            if (result == null)
            {
                return new ErrorResult("Böyle Bir Kiralama İşlemi Bulunamadı");
            }
            _rentalDal.Delete(result);
            return new SuccessResult(Messages.RentalDeleted);
        }

        //[SecuredOperation("admin,moderator")]
        public IResult Update(RentalUpdateDto rentalUpdateDto)
        {
            var result = _rentalDal.Get(r => r.RentalId == rentalUpdateDto.Id);
            if (result == null)
            {
                return new ErrorResult("Böyle Bir Kiralık Araç Kayıdı Yok");
            }
            var newRental = _mapper.Map(rentalUpdateDto, result);
            _rentalDal.Update(newRental);
            return new SuccessResult(Messages.RentalUpdated);
        }
        #endregion

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IDataResult<Rental> GetByRentalId(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == rentalId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }
    }
}
