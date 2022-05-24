using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    internal class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;
        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper, IModelService modelService)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        #region Void

        //[SecuredOperation("admin,moderator")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            IResult result = BusinessRules.Run(
                  CheckIfImageCountOfCarCorrect(carImage.CarId),
                  TurnDateNowAndCheckImage(carImage)
                  );
            if (result != null)
            {
                return result;
            }

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            IResult result = BusinessRules.Run(
                 CheckIfImageCountOfCarCorrect(carImage.CarId),
                 TurnDateNowAndCheckImage(carImage)
                 );
            if (result != null)
            {
                return result;
            }

            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }
        #endregion

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImageListed);
        }

        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == imageId));
        }

        #region Özel Methodlar

        private IResult CheckIfImageCountOfCarCorrect(int modelId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == modelId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.ImageCountOfCarError);
            }
            return new SuccessResult();
        }

        private IResult TurnDateNowAndCheckImage(CarImage carImage)
        {
            carImage.Date = DateTime.Now;
            if (carImage.ImagePath == null)
            {
                carImage.ImagePath = "DefaultImage.jpg";
            }
            return new SuccessResult();
        }
        #endregion
    }
}
