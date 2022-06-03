using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs.ColorDto;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IColorService
    {
       IDataResult<List<Color>> GetAll();
       IDataResult<Color> GetColorId(int colorId);

       IResult Add(ColorAddDto colorAddDto);
       IResult Update(ColorUpdateDto colorUpdateDto);
       IResult Delete(ColorDeleteDto colorDeleteDto);
    }
}
