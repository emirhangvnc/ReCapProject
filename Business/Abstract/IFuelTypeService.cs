using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs.FuelTypeDto;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IFuelTypeService
    {
        IDataResult<List<FuelType>> GetAll();
        IDataResult<FuelType> GetFuelTypeId(int fuelTypeId);
        IResult Add(FuelTypeAddDto fuelTypeAddDto);
        IResult Delete(FuelTypeDeleteDto fuelTypeDeleteDto);
        IResult Update(FuelTypeUpdateDto fuelTypeUpdateDto);
    }
}
