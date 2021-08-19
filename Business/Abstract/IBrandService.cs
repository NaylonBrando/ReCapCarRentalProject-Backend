using Core.Ultilities.Results;
using Entities.Concrate;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();

        IDataResult<Brand> GetById(int id);

        IResult Add(Brand T);

        IResult Delete(Brand T);

        IResult Update(Brand T);
    }
}