using Core.Ultilities.Results;
using Entities.Concrate;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();

        IDataResult<Color> GetById(int id);

        IResult Add(Color T);

        IResult Delete(Color T);

        IResult Update(Color T);
    }
}