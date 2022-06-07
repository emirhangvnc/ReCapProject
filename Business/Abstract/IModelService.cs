using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs.ModelDto;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IModelService
    {
        IDataResult<Model> GetByModelId(int modelId);

        IDataResult<List<Model>> GetAll();
        IDataResult<List<Model>> GetByBrandId(int brandId);
        IDataResult<List<Model>> GetByColorId(int colorId);
        IDataResult<List<ModelDetailDto>> GetModelDetails();

        IResult Add(ModelAddDto modelAddDto);
        IResult Delete(ModelDeleteDto modelDeleteDto);
        IResult Update(ModelUpdateDto modelUpdateDto);
    }
}
