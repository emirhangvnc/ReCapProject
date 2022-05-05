using Entities.Concrete;
using Core.Entities;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IModelDal : IEntityRepository<Model>
    {
        List<ModelDetailDto> GetModelDetails();
    }
}
