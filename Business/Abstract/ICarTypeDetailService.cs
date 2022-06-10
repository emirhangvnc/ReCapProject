using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs.CarTypeDetailDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    
    public interface ICarTypeDetailService
    {
        IDataResult<List<CarTypeDetail>> GetAll();

        IDataResult<CarTypeDetail> GetCarTypeDetailId(int detailId);

        IResult Add(CarTypeDetailAddDto carTypeDetailAddDto);
        IResult Delete(CarTypeDetailDeleteDto carTypeDetailDeleteDto);
        IResult Update(CarTypeDetailUpdateDto carTypeDetailUpdateDto);
    }
}
