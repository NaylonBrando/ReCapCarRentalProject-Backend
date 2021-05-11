using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandrDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandrDal = brandDal;
        }
        public void Add(Brand brand)
        {
            _brandrDal.Add(brand);
        }
        public void Update(Brand brand)
        {
            _brandrDal.Update(brand);
        }

        public void Delete(Brand brand)
        {
            _brandrDal.Delete(brand);
        }

        public List<Brand> GetAll()
        {
            return _brandrDal.GetAll();
        }
        public List<Brand> GetCarsByBrandId(int id)
        {
            return _brandrDal.GetAll(p => p.BrandId == id);
        }
    }
}
