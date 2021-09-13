using Core.Ultilities.Results;
using Entities.Concrate;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IFuelService
    {
        IDataResult<List<Fuel>> GetAll();

        IDataResult<Fuel> GetById(int id);

        IResult Add(Fuel T);

        IResult Delete(Fuel T);

        IResult Update(Fuel T);
    }



}