using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Ultilities.Results;
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

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult("Başarıyla Düzenlendi");

            }
            return new ErrorResult("Düzenlenemedi!");
        }
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Delete(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Delete(car);
                return new SuccessResult("Başarıyla Düzenlendi");

            }
            return new ErrorResult("Düzenlenemedi!");
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<Car>>  GetCarsByBrandId(int id)
        {
            //Filtreleme işlemi burada gerçekleştiriliyor
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == id));
        }

        public IDataResult<List<CarDetailDto>> GetAllCarWithDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
    }

}