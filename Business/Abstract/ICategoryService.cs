using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs.CategoryDto;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> GetCategoryId(int categoryId);

        IResult Add(CategoryAddDto categoryAddDto);
        IResult Update(CategoryUpdateDto categoryUpdateDto);
        IResult Delete(CategoryDeleteDto categoryDeleteDto);
    }
}
