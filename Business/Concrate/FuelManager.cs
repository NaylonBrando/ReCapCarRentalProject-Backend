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
    public class FuelManager : IFuelService
    {
        private IFuelDal _fuelDal;

        public FuelManager(IFuelDal fuelDal)
        {
            _fuelDal = fuelDal;
        }

        [CacheRemoveAspect("IFuelService.Get")]
        public IResult Add(Fuel fuel)
        {
            _fuelDal.Add(fuel);
            return new SuccessResult(Messages.SuccessAdded);
        }

        [CacheRemoveAspect("IFuelService.Get")]
        public IResult Update(Fuel fuel)
        {
            _fuelDal.Update(fuel);
            return new SuccessResult(Messages.SuccessAdded);
        }

        [CacheRemoveAspect("IFuelService.Get")]
        public IResult Delete(Fuel fuel)
        {
            _fuelDal.Delete(fuel);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Fuel>> GetAll()
        {
            return new SuccessDataResult<List<Fuel>>(_fuelDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<Fuel> GetById(int id)
        {
            return new SuccessDataResult<Fuel>(_fuelDal.Get(p => p.Id == id));
        }
    }
}
