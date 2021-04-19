using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrate
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public bool Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return true;
            }
            return false;
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }
    }
}