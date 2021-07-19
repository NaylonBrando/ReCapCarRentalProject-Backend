using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
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

        //Attributelerin öncelik sıraları aspect icinde verilmistir.
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.SuccessAdded);
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Update(car);
                return new SuccessResult("Başarıyla Düzenlendi");
            }
            return new ErrorResult("Düzenlenemedi!");
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Delete(car);
                return new SuccessResult("Başarıyla Düzenlendi");
            }
            return new ErrorResult("Düzenlenemedi!");
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        [PerformanceAspect(5)]
        [CacheAspect] //Parametreler CacheAspect icinde kontrol edildi
        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int id)
        {
            //Filtreleme işlemi burada gerçekleştiriliyor
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(p => p.BrandId == id));
        }

        [PerformanceAspect(5)]
        [CacheAspect] ////Parametreler CacheAspect icinde kontrol edildi
        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(p => p.ColorId == id));
        }

        [PerformanceAspect(5)]
        [CacheAspect] //Parametreler CacheAspect icinde kontrol edildi
        public IDataResult<Car> GetById(int id)
        {
            //Burayi sonra düzenle direkt SuccessDataResult yolladgimiz icin standart true yolluyor
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == id));
        }

        public IDataResult<List<CarDetailDto>> GetAllCarWithDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
    }
}