﻿using Core.Entities;
using Core.Ultilities.Results;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IServiceBase<T> where T : class, IEntity, new()
    {
        IDataResult<List<T>> GetAll();

        IDataResult<T> GetById(int id);

        IResult Add(T T);

        IResult Delete(T T);

        IResult Update(T T);
    }
}