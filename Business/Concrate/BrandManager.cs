using Business.Abstract;
using Business.Constants;
using Core.Ultilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand T)
        {
            _brandDal.Add(T);
            return new SuccessResult(Messages.SuccessAdded);
        }

        public IResult Delete(Brand T)
        {
            _brandDal.Delete(T);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(p => p.BrandId == id));
        }

        public IResult Update(Brand T)
        {
            _brandDal.Update(T);
            return new SuccessResult(Messages.SuccessUpdated);
        }
    }
}
