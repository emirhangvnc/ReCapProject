using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Entities.DTOs.FuelTypeDto;
using Core.Utilities.Results.Concrete;
using System.Linq;
using DataAccess.Abstract;
using AutoMapper;
using Entities.Concrete;
using System.Collections.Generic;
using Business.ValidationRules.FuelTypeValidator;

namespace Business.Concrete
{
    public class FuelTypeManager:IFuelTypeService
    {
        IFuelTypeDal _fuelTypeDal;
        IMapper _mapper;
        public FuelTypeManager(IFuelTypeDal fuelTypeDal,IMapper mapper)
        {
            _fuelTypeDal = fuelTypeDal; 
            _mapper = mapper;
        }

        #region Void işlemleri

        //[SecuredOperation("admin,moderator")]
        [ValidationAspect(typeof(FuelTypeAddDtoValidator))]
        public IResult Add(FuelTypeAddDto fuelTypeAddDto)
        {
            var result = _fuelTypeDal.Get(f => f.FuelTypeName == fuelTypeAddDto.Name);
            if (result != null)
                return new ErrorResult("Böyle Bir Yakıt Tipi Zaten Mevcut");
            var fuelType = _mapper.Map<FuelType>(fuelTypeAddDto);
            _fuelTypeDal.Add(fuelType);
            return new SuccessResult(Messages.FuelTypeAdded);
        }

        //[SecuredOperation("admin,moderator")]
        [ValidationAspect(typeof(FuelTypeDeleteDtoValidator))]
        public IResult Delete(FuelTypeDeleteDto fuelTypeDeleteDto)
        {
            var result = _fuelTypeDal.GetAll().SingleOrDefault(m => m.FuelTypeId == fuelTypeDeleteDto.Id);
            if (result != null)
            {
                _fuelTypeDal.Delete(result);
                return new SuccessResult(Messages.FuelTypeDeleted);
            }
            return new ErrorResult("Silinecek Yakıt Tipi Bulunamadı");
        }

        // [SecuredOperation("admin,moderator")]
        [ValidationAspect(typeof(FuelTypeUpdateDtoValidator))]
        public IResult Update(FuelTypeUpdateDto fuelTypeUpdateDto)
        {
            var result = _fuelTypeDal.Get(f => f.FuelTypeId == fuelTypeUpdateDto.Id);
            if (result == null)
            {
                return new ErrorResult("Bu Veride Bir Müşteri Yok");
            }
            var fuelType = _mapper.Map(fuelTypeUpdateDto, result);
            _fuelTypeDal.Update(fuelType);
            return new SuccessResult(Messages.FuelTypeUpdated);
        }
        #endregion

        public IDataResult<List<FuelType>> GetAll()
        {
            return new SuccessDataResult<List<FuelType>>(_fuelTypeDal.GetAll(),Messages.FuelTypesListed);
        }

        public IDataResult<FuelType> GetFuelTypeId(int fuelTypeId)
        {
            return new SuccessDataResult<FuelType>(_fuelTypeDal.Get(f=>f.FuelTypeId==fuelTypeId));
        }
    }
}
