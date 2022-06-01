using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Helpers;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Results.Concrete.BaseConcrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using Core.Utilities.Helpers.FileHelper;

namespace Business.Concrete
{
    internal class CarImageManager : ICarImageService
    {
        private static ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
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
            var imageResult = FileHelper.Upload(formFile);
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }

            carImage.ImagePath = imageResult.Message;
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            var result = _carImageDal.Get(c => c.Id == carImage.Id);
            if (result==null)
            {
                return new ErrorResult("Image Not Found");
            }
            FileHelper.Delete(result.ImagePath);
            _carImageDal.Delete(result);
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
            var isImage=_carImageDal.Get(c=>c.Id == carImage.CarId);
            if (isImage==null)
            {
                return new ErrorResult(Messages.CarImageNotFound);
            }
            var updatedFile = FileHelper.Update(formFile, isImage.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            carImage.ImagePath = updatedFile.Message;
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

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId),"Araba Resimleri Listelendi");
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

        private static IResult CheckTheCarImageExists(int fileId)
        {
            return _carImageDal.Get(c => c.Id == fileId) != null ? new Result(true)
                : new ErrorResult(Messages.CarImageMustBeExists);
        }
        #endregion
    }
}
