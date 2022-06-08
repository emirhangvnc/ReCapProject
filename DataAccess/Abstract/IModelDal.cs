using Entities.Concrete;
using Core.Entities;
using System.Collections.Generic;
using Entities.DTOs.ModelDto;
using System.Linq.Expressions;
using System;

namespace DataAccess.Abstract
{
    public interface IModelDal : IEntityRepository<Model>
    {
        List<ModelDetailDto> GetModelDetails(Expression<Func<ModelDetailDto,bool>>filter=null);
    }
}
