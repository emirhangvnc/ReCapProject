using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.CarTypeDetailDto;
using AutoMapper;
using System.Collections.Generic;
using Business.ValidationRules.FluentValidation.CarTypeDetailValidator;
using System.Linq;

namespace Business.Concrete
{
    public class CarTypeDetailManager : ICarTypeDetailService
    {
        ICarTypeDetailDal _carTypeDetailDal;
        IMapper _mapper;
        public CarTypeDetailManager(ICarTypeDetailDal carTypeDetailDal,IMapper mapper)
        {
            _carTypeDetailDal = carTypeDetailDal;
            _mapper = mapper;
        }

        #region Void işlemleri

        //[SecuredOperation("admin,moderator")]
        [ValidationAspect(typeof(CarTypeDetailAddDtoValidator))]
        public IResult Add(CarTypeDetailAddDto carTypeDetailAddDto)
        {
            var result = _carTypeDetailDal.Get(c => c.CategoryId == carTypeDetailAddDto.CategoryId&&c.FuelTypeId==carTypeDetailAddDto.FuelTypeId);
            if (result != null)
                return new ErrorResult($"Böyle Bir Tip Mevcut, ID={result.CarTypeDetailId}");
            var detail=_mapper.Map<CarTypeDetail>(carTypeDetailAddDto);   
            _carTypeDetailDal.Add(detail);
            return new SuccessResult(Messages.CarTypeDetailAdded);
        }

        //[SecuredOperation("admin,moderator")]
        [ValidationAspect(typeof(CarTypeDetailDeleteDtoValidator))]
        public IResult Delete(CarTypeDetailDeleteDto carTypeDetailDeleteDto)
        {
            var result = _carTypeDetailDal.Get(m => m.CarTypeDetailId == carTypeDetailDeleteDto.Id);
            if (result != null)
            {
                _carTypeDetailDal.Delete(result);
                return new SuccessResult(Messages.CarTypeDetailDeleted);
            }
            return new ErrorResult("Böyle Bir Araba Detayı Bulunmamakta");
        }

        //[SecuredOperation("admin,moderator")]
        [ValidationAspect(typeof(CarTypeDetailUpdateDtoValidator))]
        public IResult Update(CarTypeDetailUpdateDto carTypeDetailUpdateDto)
        {
            var detail = _carTypeDetailDal.GetAll().SingleOrDefault(c => c.CategoryId == carTypeDetailUpdateDto.CategoryId && c.FuelTypeId == carTypeDetailUpdateDto.FuelTypeId);
            if (detail == null)
            {
                return new ErrorResult("Boyle Bir Araba Detayı Bulunmamaktadır");
            }
            var newDetail = _mapper.Map<CarTypeDetail>(carTypeDetailUpdateDto);
            _carTypeDetailDal.Update(newDetail);
            return new SuccessResult(Messages.CarTypeDetailUpdated);
        }
        #endregion

        public IDataResult<List<CarTypeDetail>> GetAll()
        {
            return new SuccessDataResult<List<CarTypeDetail>>(_carTypeDetailDal.GetAll(),Messages.CarTypeDetailListed);
        }

        public IDataResult<CarTypeDetail> GetCarTypeDetailId(int detailId)
        {
            return new SuccessDataResult<CarTypeDetail>(_carTypeDetailDal.Get(c => c.CarTypeDetailId == detailId));
        }
    }
}
