using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation.ColorValidator;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using AutoMapper;
using System.Linq;
using Entities.DTOs.ColorDto;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ColorManager:IColorService
    {
        IColorDal _colorDal;
        IMapper _mapper;
        public ColorManager(IColorDal colorDal,IMapper mapper)
        {
            _colorDal = colorDal;
            _mapper = mapper;
        }

        #region Void işlemleri

        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(ColorAddDtoValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Add(ColorAddDto colorAddDto)
        {
            var result = _colorDal.Get(c => c.ColorName == colorAddDto.Name);
            if (result != null)
                return new ErrorResult("Böyle Bir Renk Zaten Mevcut");

            var color = _mapper.Map<Color>(colorAddDto);
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(ColorDeleteDtoValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Delete(ColorDeleteDto colorDeleteDto)
        {
            var result = _colorDal.GetAll().SingleOrDefault(c => c.ColorId == colorDeleteDto.Id);
            if (result != null)
            {
                _colorDal.Delete(result);
                return new SuccessResult(Messages.ColorDeleted);
            }
            return new ErrorResult("Renk Bulunamadı");
        }

        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(ColorUpdateDtoValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Update(ColorUpdateDto colorUpdateDto)
        {
            var result = _colorDal.Get(c => c.ColorId == colorUpdateDto.Id);
            if (result == null)
            {
                return new ErrorResult("Bu Veride Bir Renk Yok");
            }
            var color = _mapper.Map(colorUpdateDto, result);
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
        #endregion

        [CacheAspect]
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.ColorsListed);
        }

        public IDataResult<Color> GetColorId(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == colorId));
        }
    }
}