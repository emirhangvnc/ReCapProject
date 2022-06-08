using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation.CarImageValidator;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Results.Concrete.BaseConcrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.CarImageDto;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using Core.Utilities.Helpers.FileHelper;

namespace Business.Concrete
{
    internal class CarImageManager : ICarImageService
    {
        private static ICarImageDal _carImageDal;
        IMapper _mapper;
        public CarImageManager(ICarImageDal carImageDal,IMapper mapper)
        {
            _carImageDal = carImageDal;
            _mapper = mapper;
        }

        #region Void

        //[SecuredOperation("admin,moderator")]
        //[ValidationAspect(typeof(CarImageAddDtoValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageLimitExpired(carImage.CarId),
                CheckIfImageExtensionValid(file)
                );

            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        //[ValidationAspect(typeof(CarImageDeleteDtoValidator))]
        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageExists(carImage.ImageId)
                );
            if (result != null)
            {
                return result;
            }
            string path = GetByImageId(carImage.ImageId).Data.ImagePath;
            FileHelper.Delete(path);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        //[ValidationAspect(typeof(CarImageUpdateDtoValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageLimitExpired(carImage.CarId),
                CheckIfImageExtensionValid(file),
                CheckIfImageExists(carImage.ImageId)
                );

            if (result != null)
            {
                return result;
            }

            CarImage oldCarImage = GetByImageId(carImage.ImageId).Data;
            carImage.ImagePath = FileHelper.Update(file, oldCarImage.ImagePath);
            carImage.Date = DateTime.Now;
            carImage.CarId = oldCarImage.CarId;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }
        #endregion

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImageListed);
        }

        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.ImageId == imageId));
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId),"Araba Resimleri Listelendi");
        }

        #region Özel Methodlar

        private IResult CheckIfImageLimitExpired(int carId)
        {
            int result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
                return new ErrorResult(Messages.ImageLimitExpiredForCar);
            return new SuccessResult();
        }

        private IResult CheckIfImageExtensionValid(IFormFile file)
        {
            bool isValidFileExtension = Messages.ValidImageFileTypes.Any(t => t == Path.GetExtension(file.FileName).ToUpper());
            if (!isValidFileExtension)
                return new ErrorResult(Messages.InvalidImageExtension);
            return new SuccessResult();
        }

        private static IResult CheckTheCarImageExists(int fileId)
        {
            return _carImageDal.Get(c => c.ImageId == fileId) != null ? new Result(true)
                : new ErrorResult(Messages.CarImageMustBeExists);
        }

        private IResult CheckIfImageExists(int id)
        {
            if (_carImageDal.IsExist(id))
                return new SuccessResult();
            return new ErrorResult(Messages.CarImageMustBeExists);
        }
        #endregion
    }
}