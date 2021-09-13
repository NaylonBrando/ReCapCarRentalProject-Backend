using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Ultilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class GearManager : IGearService
    {
        private IGearDal _gearDal;

        public GearManager(IGearDal gearDal)
        {
            _gearDal = gearDal;
        }

        [CacheRemoveAspect("IGearService.Get")]
        public IResult Add(Gear gear)
        {
            _gearDal.Add(gear);
            return new SuccessResult(Messages.SuccessAdded);
        }

        [CacheRemoveAspect("IGearService.Get")]
        public IResult Update(Gear gear)
        {
            _gearDal.Update(gear);
            return new SuccessResult(Messages.SuccessAdded);
        }

        [CacheRemoveAspect("IGearService.Get")]
        public IResult Delete(Gear gear)
        {
            _gearDal.Delete(gear);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Gear>> GetAll()
        {
            return new SuccessDataResult<List<Gear>>(_gearDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<Gear> GetById(int id)
        {
            return new SuccessDataResult<Gear>(_gearDal.Get(p => p.Id == id));
        }
    }
}

