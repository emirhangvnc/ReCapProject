using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class ModelManager : IModelService
    {
        IModelDal _modelDal;
        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        #region Void işlemleri

        //[SecuredOperation("admin,moderator")]
        [ValidationAspect(typeof(ModelValidator))]
        [CacheRemoveAspect("IModelService.Get")]
        public IResult Add(Model model)
        {
            _modelDal.Add(model);
            return new SuccessResult(Messages.ModelAdded);
        }

        //[SecuredOperation("admin,moderator")]
        [CacheRemoveAspect("IModelService.Get")]
        public IResult Delete(Model model)
        {
            _modelDal.Delete(model);
            return new SuccessResult(Messages.ModelDeleted);
        }

        //[SecuredOperation("admin,moderator")]
        [CacheRemoveAspect("IModelService.Get")]
        public IResult Update(Model model)
        {
            _modelDal.Update(model);
            return new SuccessResult(Messages.ModelUpdated);
        }
        #endregion

        public IDataResult<Model> GetByModelId(int modelId)
        {
            return new SuccessDataResult<Model>(_modelDal.Get(m => m.ModelId == modelId));
        }

        [CacheAspect]
        public IDataResult<List<Model>> GetAll()
        {
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll(), Messages.ModelsListed);
        }
        public IDataResult<List<Model>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll().Where(m => m.BrandId == brandId).ToList());
        }
        public IDataResult<List<Model>> GetByColorId(int colorId)
        {
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll().Where(c => c.ColorId == colorId).ToList());
        }

        public IDataResult<List<Model>> GetByDailyPriceContains(decimal minPrice, decimal maxPrice)
        {
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll().Where(c => c.DailyPrice >= minPrice && c.DailyPrice <= maxPrice).ToList());
        }
        public IDataResult<List<Model>> GetByDailyPrice(decimal price)
        {
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll().Where(c => c.DailyPrice == price).ToList());
        }
        public IDataResult<List<Model>> GetByDailyPriceBuyuktur(decimal price)
        {
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll().Where(c => c.DailyPrice >= price).ToList());
        }
        public IDataResult<List<Model>> GetByDailyPriceKucuktur(decimal price)
        {
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll().Where(c => c.DailyPrice <= price).ToList());
        }

        [CacheAspect]
        public IDataResult<List<ModelDetailDto>> GetModelDetails()
        {
            return new SuccessDataResult<List<ModelDetailDto>>(_modelDal.GetModelDetails());
        }

    }
}
