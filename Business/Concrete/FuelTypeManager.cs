using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class FuelTypeManager:IFuelTypeService
    {
        IFuelTypeDal _fuelTypeDal;
        public FuelTypeManager(IFuelTypeDal fuelTypeDal)
        {
            _fuelTypeDal = fuelTypeDal; 
        }

        public IResult Add(FuelType fuelType)
        {
            _fuelTypeDal.Add(fuelType);
            return new SuccessResult(Messages.FuelTypeAdded);
        }
        public IResult Delete(FuelType fuelType)
        {
            _fuelTypeDal.Delete(fuelType);
            return new SuccessResult(Messages.FuelTypeDeleted);
        }
        public IResult Update(FuelType fuelType)
        {
            _fuelTypeDal.Update(fuelType);
            return new SuccessResult(Messages.FuelTypeUpdated);
        }

        public IDataResult<List<FuelType>> GetAll()
        {
            return new SuccessDataResult<List<FuelType>>(_fuelTypeDal.GetAll(),Messages.FuelTypesListed);
        }
        public IDataResult<FuelType> GetFuelTypeId(int fuelTypeId)
        {
            return new SuccessDataResult<FuelType>(_fuelTypeDal.Get(f=>f.Fuel_Id==fuelTypeId));
        }
    }
}
