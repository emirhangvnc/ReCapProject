using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs.RentalDto;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetByRentalId(int rentalId);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();


        IResult Add(RentalAddDto rentalAddDto);
        IResult Delete(RentalDeleteDto rentalDeleteDto);
        IResult Update(RentalUpdateDto rentalUpdateDto);
    }
}
