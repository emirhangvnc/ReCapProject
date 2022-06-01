using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using Core.Utilities.Results.Concrete;
using System.Linq;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Entities.DTOs.BrandDto;
using AutoMapper;
using Business.ValidationRules.FluentValidation.BrandValidator;

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

        //[SecuredOperation("admin,moderator,brand.add")]
        [ValidationAspect(typeof(BrandAddDtoValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Add(BrandAddDto brandAddDto)
        {
            Brand brand = new Brand
            {
                BrandName = brandAddDto.Name
            };

            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        //[SecuredOperation("admin,moderator")]
        [ValidationAspect(typeof(BrandDeleteDtoValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Delete(BrandDeleteDto brandDeleteDto)
        {
            var brand = _brandDal.GetAll().SingleOrDefault(b => b.BrandId == brandDeleteDto.Id);
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        //[SecuredOperation("admin,moderator")]
        [ValidationAspect(typeof(BrandUpdateDtoValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Update(BrandUpdateDto brandUpdateDto)
        {
            var brand = _brandDal.GetAll().SingleOrDefault(b => b.BrandId == brandUpdateDto.Id);
            if (brand == null)
            {
                return new ErrorResult("Boyle Bir Marka Bulunmamaktadır");
            }
            brand.BrandName = brandUpdateDto.Name;
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
