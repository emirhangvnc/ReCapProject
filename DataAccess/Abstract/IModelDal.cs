using Entities.Concrete;
using Core.Entities;
using System.Collections.Generic;
using Entities.DTOs.ModelDto;

namespace DataAccess.Abstract
{
    public interface IModelDal : IEntityRepository<Model>
    {
        List<ModelDetailDto> GetModelDetails();
    }
}
