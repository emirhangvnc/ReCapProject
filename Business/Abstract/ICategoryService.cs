using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> GetCategoryId(int categoryId);

        IResult Add(Category category);
        IResult Update(Category category);
        IResult Delete(Category category);
    }
}
