﻿using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetUserId(int userId);

        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);

    }
}
