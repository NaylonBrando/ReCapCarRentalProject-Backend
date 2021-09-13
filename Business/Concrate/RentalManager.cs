using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Ultilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Concrate
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;
        private ICarService _carService;

        public RentalManager(IRentalDal rentalDal, ICarService carService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetRentalById(int id)
        {
            throw new NotImplementedException();
        }

        [CacheAspect]
        public IDataResult<List<CarRentalDetailDto>> GetAllRentalsWithDetails()
        {
            return new SuccessDataResult<List<CarRentalDetailDto>>(_rentalDal.GetAllRentalsWithDetails());
        }


        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Rent(Rental rental)
        {

            var caravaiblecontrol = _carService.GetById(rental.CarId);
            if (caravaiblecontrol == null)
            {
                return new ErrorResult(Messages.CarİsNull);
            }

            //simdilik iptal
            //if (caravaiblecontrol.Data.Available == false)
            //{
            //    return new ErrorResult(Messages.CarİsUnavaible);
            //}
            //caravaiblecontrol.Data.Available = false;

            //_carService.Update(caravaiblecontrol.Data);


            _rentalDal.Add(rental);
            return new SuccessResult(Messages.SuccessfullyLeased);
        }

        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Return(Rental rental)
        {
            //Bu tablo bir nevi log olarak tutulacak
            //Kayıtlar return edilince güncellenecek
            var rentalControl = _rentalDal.Get(r => r.Rental_Id == rental.Rental_Id);
            if (rentalControl == null)
            {
                return new ErrorResult("Böyle bir kiralama kaydı yok!");
            }
            rentalControl.ReturnDate = DateTime.Now;

            var updateofCarAvaible = _carService.GetById(rental.CarId);
            //updateofCarAvaible.Data.Available = true;
            _carService.Update(updateofCarAvaible.Data);
            _rentalDal.Update(rentalControl);

            return new SuccessResult("Araç iade edildi!");
        }

        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult UpdateRental(Rental rental)
        {
            var rentalControl = _rentalDal.Get(r => r.Rental_Id == rental.Rental_Id);
            if (rentalControl == null)
            {
                return new ErrorResult("Böyle bir kiralama kaydı yok!");
            }
            rentalControl.ReturnDate = rental.ReturnDate;
            _rentalDal.Update(rentalControl);
            return new SuccessResult("Arac iade tarihiniz " + rentalControl.ReturnDate + " tarihine güncelledi");
        }

        public IDataResult<Rental> GetLastRentalById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.GetLastRentalById(id));
        }

        public IResult CheckRentalDate(RentalCheck rental)
        {
            var result = _rentalDal.CheckRentalDate(rental);
            if (result==null)
            {
                return new SuccessResult("Secilen tarih kiralamaya uygun");
                
            }
            else
            {
                return new ErrorResult("Secilen tarihte secili arac kiralanmis");
            }
            
        }
    }
}