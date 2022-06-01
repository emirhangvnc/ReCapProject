using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs.BrandDto;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();

        IDataResult<Brand> GetBrandId(int brandId);

        IResult Add(BrandAddDto brand);
        IResult Update(BrandUpdateDto brandUpdateDto);
        IResult Delete(BrandDeleteDto brandDeleteDto);
    }
}
