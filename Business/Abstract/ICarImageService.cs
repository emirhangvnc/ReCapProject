using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs.CarImageDto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetImagesByCarId(int Id);
        IDataResult<CarImage> GetByImageId(int imageId);

        IResult Add(IFormFile formFile, CarImageAddDto carImageAddDto);
        IResult Delete(CarImageDeleteDto carImageDeleteDto);
        IResult Update(IFormFile formFile, CarImageUpdateDto carImageUpdateDto);
    }
}
