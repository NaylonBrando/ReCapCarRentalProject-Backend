using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Ultilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class FindeksScoreManager: IFindeksScoreService
    {
        private IFindeksScoreDal _findeksScoreDal;

        public FindeksScoreManager(IFindeksScoreDal findeksScoreDal)
        {
            _findeksScoreDal = findeksScoreDal;
        }

        [ValidationAspect(typeof(FindeksScoreValidator))]
        [CacheRemoveAspect("IFindeksScoreService.Get")]
        public IResult Add(FindeksScore findeksScore)
        {
            _findeksScoreDal.Add(findeksScore);
            return new SuccessResult(Messages.SuccessAdded);
        }

        [ValidationAspect(typeof(FindeksScoreDeleteValidator))]
        [CacheRemoveAspect("IFindeksScoreService.Get")]
        public IResult Delete(FindeksScore findeksScore)
        {
            _findeksScoreDal.Delete(findeksScore);
            return new SuccessResult(Messages.SuccessDeleted);
        }


        [ValidationAspect(typeof(FindeksScoreUpdateValidator))]
        [CacheRemoveAspect("IFindeksScoreService.Get")]
        public IResult Update(FindeksScore findeksScore)
        {
            _findeksScoreDal.Update(findeksScore);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        //[PerformanceAspect(5)]
        //[CacheAspect]
        public IDataResult<List<FindeksScore>> GetAll()
        {
            return new SuccessDataResult<List<FindeksScore>>(_findeksScoreDal.GetAll());
        }

        [PerformanceAspect(5)]
        //[CacheAspect]
        public IDataResult<FindeksScore> GetByUserId(int id)
        {
            return new SuccessDataResult<FindeksScore>(_findeksScoreDal.Get(p => p.UserId == id));
        }
    }
}
