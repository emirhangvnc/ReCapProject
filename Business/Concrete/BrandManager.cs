﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using Core.Utilities.Results.Concrete;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        #region Void işlemleri

        [SecuredOperation("admin,moderator,brand.add")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        [SecuredOperation("admin,moderator")]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        [SecuredOperation("admin,moderator")]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
        #endregion

        [CacheAspect]
        public IDataResult<List<Brand>> GetAll()
        {
           return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.BrandsListed);

        }

        [CacheAspect]
        public IDataResult<Brand> GetBrandId(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b=>b.BrandId==brandId));
        }
    }
}
