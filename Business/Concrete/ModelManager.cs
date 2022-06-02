using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Business.ValidationRules.FluentValidation.ModelValidator;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class ModelManager : IModelService
    {
        IModelDal _modelDal;
        IMapper _mapper;
        public ModelManager(IModelDal modelDal,IMapper mapper)
        {
            _modelDal = modelDal;
            _mapper = mapper;
        }

        #region Void işlemleri

        //[SecuredOperation("admin,moderator")]
        [ValidationAspect(typeof(ModelAddDtoValidator))]
        [CacheRemoveAspect("IModelService.Get")]
        public IResult Add(ModelAddDto modelAddDto)
        {
            var result = _modelDal.GetAll().SingleOrDefault(b => b.ModelName == modelAddDto.ModelName);
            if (result != null)
                return new ErrorResult("Bu İsimde Model İsmi Mevcut");

            var model = _mapper.Map<Model>(modelAddDto);
            _modelDal.Add(model);
            return new SuccessResult(Messages.ModelAdded);
        }

        //[SecuredOperation("admin,moderator")]
        [ValidationAspect(typeof(ModelDeleteDtoValidator))]
        [CacheRemoveAspect("IModelService.Get")]
        public IResult Delete(ModelDeleteDto modelDeleteDto)
        {
            var result = _modelDal.Get(m => m.ModelId == modelDeleteDto.Id);
            if (result!=null)
            {
                _modelDal.Delete(result);
                return new SuccessResult(Messages.ModelDeleted);
            }
            return new ErrorResult("Böyle Bir Model Bulunmamakta");
        }

        //[SecuredOperation("admin,moderator")]
        [ValidationAspect(typeof(ModelUpdateDtoValidator))]
        [CacheRemoveAspect("IModelService.Get")]
        public IResult Update(ModelUpdateDto modelUpdateDto)
        {
            var result = _modelDal.Get(m => m.ModelId == modelUpdateDto.Id);
            if (result==null)
                return new ErrorResult("Bu Veride Bir Model Yok");

            var model = _mapper.Map(modelUpdateDto, result);
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
