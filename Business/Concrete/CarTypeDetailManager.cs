using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarTypeDetailManager : ICarTypeDetailService
    {
        ICarTypeDetailDal _carTypeDetailDal;
        public CarTypeDetailManager(ICarTypeDetailDal carTypeDetailDal)
        {
            _carTypeDetailDal = carTypeDetailDal;
        }

        #region Void işlemleri

        //[SecuredOperation("admin,moderator")]
        [ValidationAspect(typeof(CarTypeDetailValidator))]
        public IResult Add(CarTypeDetail carTypeDetail)
        {
            _carTypeDetailDal.Add(carTypeDetail);
            return new SuccessResult(Messages.CarTypeDetailAdded);
        }

        //[SecuredOperation("admin,moderator")]
        public IResult Delete(CarTypeDetail carTypeDetail)
        {
            _carTypeDetailDal.Delete(carTypeDetail);
            return new SuccessResult(Messages.CarTypeDetailDeleted);
        }

        //[SecuredOperation("admin,moderator")]
        public IResult Update(CarTypeDetail carTypeDetail)
        {
            _carTypeDetailDal.Update(carTypeDetail);
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
