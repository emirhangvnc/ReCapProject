using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using System.Linq;
using DataAccess.Abstract;
using Business.ValidationRules.FluentValidation.CategoryValidator;
using Entities.Concrete;
using Entities.DTOs.CategoryDto;
using System.Collections.Generic;
using AutoMapper;

namespace Business.Concrete
{
    public class CategoryManager:ICategoryService
    {
        ICategoryDal _categoryDal;
        IMapper _mapper;
        public CategoryManager(ICategoryDal categoryDal,IMapper mapper)
        {
            _categoryDal= categoryDal;
            _mapper = mapper;
        }

        #region Void işlemleri

        //[SecuredOperation("admin,moderator")]
        [ValidationAspect(typeof(CategoryAddDtoValidator))]
        public IResult Add(CategoryAddDto categoryAddDto)
        {
            var result = _categoryDal.Get(c => c.CategoryName == categoryAddDto.Name);
            if (result != null)
                return new ErrorResult("Böyle Bir Category Zaten Mevcut");

            var category = _mapper.Map<Category>(categoryAddDto);
            _categoryDal.Add(category);
            return new SuccessResult(Messages.CategoryAdded);
        }

        //[SecuredOperation("admin,moderator")]
        public IResult Delete(CategoryDeleteDto categoryDeleteDto)
        {
            var result = _categoryDal.GetAll().SingleOrDefault(c => c.CategoryId == categoryDeleteDto.Id);
            if (result != null)
            {
                _categoryDal.Delete(result);
                return new SuccessResult(Messages.CategoryDeleted);
            }
            return new ErrorResult("Silinecek Category Bulunamadı");
        }

        //[SecuredOperation("admin,moderator")]
        public IResult Update(CategoryUpdateDto categoryUpdateDto)
        {
            var result = _categoryDal.Get(m => m.CategoryId == categoryUpdateDto.Id);
            if (result == null)
            {
                return new ErrorResult("Bu Veride Bir Müşteri Yok");
            }
            var customer = _mapper.Map(categoryUpdateDto, result);
            _categoryDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
        #endregion

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), Messages.CategoriesListed);
        }
        public IDataResult<Category> GetCategoryId(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c=>c.CategoryId==categoryId));
        }
    }
}
