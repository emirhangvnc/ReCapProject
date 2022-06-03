using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Results.Concrete.BaseConcrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using AutoMapper;
using System.Collections.Generic;
using Core.Utilities.Helpers.FileHelper;
using Entities.DTOs.CarImageDto;
using Business.ValidationRules.FluentValidation.CarImageValidator;

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
        [ValidationAspect(typeof(CarImageAddDtoValidator))]
        public IResult Add(IFormFile formFile, CarImageAddDto carImageAddDto)
        {
            IResult result = BusinessRules.Run(
                  CheckIfImageCountOfCarCorrect(carImageAddDto.CarId)
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

            var carImage = _mapper.Map<CarImage>(carImageAddDto);
            carImage.Date = DateTime.Now;
            carImage.ImagePath = imageResult.Message;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        [ValidationAspect(typeof(CarImageDeleteDtoValidator))]
        public IResult Delete(CarImageDeleteDto carImageDeleteDto)
        {
            var result = _carImageDal.Get(c => c.Id == carImageDeleteDto.Id);
            if (result==null)
            {
                return new ErrorResult("Image Not Found");
            }
            FileHelper.Delete(result.ImagePath);
            _carImageDal.Delete(result);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        [ValidationAspect(typeof(CarImageUpdateDtoValidator))]
        public IResult Update(IFormFile formFile, CarImageUpdateDto carImageUpdateDto)
        {
            IResult result = BusinessRules.Run(
                 CheckIfImageCountOfCarCorrect(carImageUpdateDto.CarId)
                 );
            if (result != null)
            {
                return result;
            }

            var isImage=_carImageDal.Get(c=>c.Id == carImageUpdateDto.CarId);
            if (isImage==null)
            {
                return new ErrorResult(Messages.CarImageNotFound);
            }

            var updatedFile = FileHelper.Update(formFile, isImage.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            var carImage = _mapper.Map(carImageUpdateDto,isImage);

            carImage.Date = DateTime.Now;
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

        private static IResult CheckTheCarImageExists(int fileId)
        {
            return _carImageDal.Get(c => c.Id == fileId) != null ? new Result(true)
                : new ErrorResult(Messages.CarImageMustBeExists);
        }
        #endregion
    }
}
