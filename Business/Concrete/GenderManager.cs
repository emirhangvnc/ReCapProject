﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class GenderManager : IGenderService
    {
        IGenderDal _genderDal;
        public GenderManager(IGenderDal genderDal)
        {
            _genderDal = genderDal;
        }

        #region Void işlemleri

        [ValidationAspect(typeof(GenderValidator))]
        public IResult Add(Gender gender)
        {
            _genderDal.Add(gender);
            return new SuccessResult(Messages.GenderAdded);
        }
        public IResult Delete(Gender gender)
        {
            _genderDal.Delete(gender);
            return new SuccessResult(Messages.GenderDeleted);
        }
        public IResult Update(Gender gender)
        {
            _genderDal.Update(gender);
            return new SuccessResult(Messages.GenderUpdated);
        }
        #endregion

        public IDataResult<List<Gender>> GetAll()
        {
            return new SuccessDataResult<List<Gender>>(_genderDal.GetAll(), Messages.GendersListed);
        }

        public IDataResult<Gender> GetGenderId(int genderId)
        {
            return new SuccessDataResult<Gender>(_genderDal.Get(g => g.GenderId == genderId));
        }

    }
}
