using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IGenderService
    {
        IDataResult<List<Gender>> GetAll();
        IDataResult<Gender> GetGenderId(int genderId);

        IResult Add(Gender gender);
        IResult Update(Gender gender);
        IResult Delete(Gender gedner);
    }
}
