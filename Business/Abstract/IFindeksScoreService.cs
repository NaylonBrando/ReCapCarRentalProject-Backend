using Core.Ultilities.Results;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFindeksScoreService
    {
        IDataResult<List<FindeksScore>> GetAll();

        IDataResult<FindeksScore> GetByUserId(int id);

        IResult Add(FindeksScore T);

        IResult Delete(FindeksScore T);

        IResult Update(FindeksScore T);
    }
}
