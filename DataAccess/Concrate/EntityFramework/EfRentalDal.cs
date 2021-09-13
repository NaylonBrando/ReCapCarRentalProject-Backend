using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfRentalDal : EfRepositoryBase<Rental, ReCapProjectDbContext>, IRentalDal
    {
        public Rental CheckRentalDate(RentalCheck rental)
        {
            using (ReCapProjectDbContext context = new ReCapProjectDbContext())
            {
                DateTime rentDate = DateTime.Parse(rental.rentDate);
                DateTime returnDate = DateTime.Parse(rental.returnDate);

                var result = from re in context.Rentals
                             where rentDate >= re.RentDate && rentDate <= re.ReturnDate && rental.carId == re.CarId || returnDate >= re.RentDate && returnDate <= re.ReturnDate && rental.carId == re.CarId
                             select new Rental
                             {
                                 CarId = re.CarId,
                                 CustomerId = re.CustomerId,
                                 Rental_Id = re.Rental_Id,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate
                             };
                return result.FirstOrDefault();
            }
        }

        public List<CarRentalDetailDto> GetAllRentalsWithDetails()
        {
            using (ReCapProjectDbContext context = new ReCapProjectDbContext())
            {
                var result = from re in context.Rentals
                             join cus in context.Customers
                             on re.CustomerId equals cus.Id
                             join ca in context.Cars
                             on re.CarId equals ca.CarId
                             join br in context.Brands
                             on ca.BrandId equals br.BrandId
                             select new CarRentalDetailDto
                             {
                                 Rental_Id = re.Rental_Id,
                                 BrandName = br.BrandName,
                                 CarName = ca.CarName,
                                 CompanyName = cus.CompanyName,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate
                             };
                return result.ToList();

            }

        }

        public Rental GetLastRentalById(int id)
        {
            using (ReCapProjectDbContext context = new ReCapProjectDbContext())
            {
                var result = from re in context.Rentals
                             where re.CarId == id
                             select new Rental
                             {
                                 CarId = re.CarId,
                                 CustomerId = re.CustomerId,
                                 Rental_Id = re.Rental_Id,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate
                             };
                return result.ToList().LastOrDefault();
            }
        }

    }
}
