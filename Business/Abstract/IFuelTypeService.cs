using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IFuelTypeService
    {
        IDataResult<List<FuelType>> GetAll();
        IDataResult<FuelType> GetFuelTypeId(int fuelTypeId);
        IResult Add(FuelType fuelType);
        IResult Delete(FuelType fuelType);
        IResult Update(FuelType fuelType);
    }
}
