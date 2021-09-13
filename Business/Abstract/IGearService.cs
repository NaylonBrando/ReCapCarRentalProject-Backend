using Core.Ultilities.Results;
using Entities.Concrate;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IGearService
    {
        IDataResult<List<Gear>> GetAll();

        IDataResult<Gear> GetById(int id);

        IResult Add(Gear T);

        IResult Delete(Gear T);

        IResult Update(Gear T);
    }



}