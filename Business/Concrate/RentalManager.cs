using Business.Abstract;
using Business.Constants;
using Core.Ultilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;
        private ICarDal _carDal;

        public RentalManager(IRentalDal rentalDal, ICarDal carDal)
        {
            _rentalDal = rentalDal;
            _carDal = carDal;
        }

        public IDataResult<List<Rental>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetRentalById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarRentalDetailDto>> GetRentalDetails()
        {
            throw new NotImplementedException();
        }

        public IResult Rental(Rental rental)
        {
            //Şart blokları

            //araba var mı kontrol
            //araba durum kontrol
            //belki sonradan kiralanan araba bilgilerini getirebilirim
            var caravaiblecontrol = _carDal.Get(c => c.CarId == rental.CarId);
            if (caravaiblecontrol == null)
            {
                return new ErrorResult(Messages.CarİsNull);
                
            }
            if ((caravaiblecontrol.Available == false))
            {
                return new ErrorResult(Messages.CarİsUnavaible);
            }
            caravaiblecontrol.Available = false;
            _carDal.Update(caravaiblecontrol);
            rental.ReturnDate = default;

            DateTime myDate = DateTime.Parse(rental.RentDate);

            if (myDate.Year <= DateTime.Now.Year)
                rental.RentDate = DateTime.Now.ToString();
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.SuccessfullyLeased);



        }

        public IResult Return(Rental rental)
        {
            //Bu tablo bir nevi log olarak tutulacak
            //Kayıtlar return edilince güncellenecek
            var rentalControl = _rentalDal.Get(r => r.Rental_Id == rental.Rental_Id);
            if (rentalControl==null)
            {
                return new ErrorResult("Böyle bir kiralama kaydı yok!");
            }
            rentalControl.ReturnDate = rental.ReturnDate;
            
            Car updateofCarAvaible = _carDal.Get(c => c.CarId == rental.CarId);
            updateofCarAvaible.Available = true;
            _carDal.Update(updateofCarAvaible);
            _rentalDal.Update(rentalControl);

            return new SuccessResult("Araç iade edildi!");
        }

        public IResult UpdateRental(Rental rental)
        {
            throw new NotImplementedException();
        }
    }
}
