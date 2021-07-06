using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfRentalDal : EfRepositoryBase<Rental, ReCapProjectDbContext>, IRentalDal
    {
        public List<CarRentalDetailDto> GetCarRentalDetails()
        {
            using (ReCapProjectDbContext context= new ReCapProjectDbContext())
            {
                var result = from re in context.Rentals
                             join cus in context.Customers
                             on re.CustomerId equals cus.CustomerId
                             join ca in context.Cars
                             on re.CarId equals ca.CarId                            
                             select new CarRentalDetailDto
                             {
                                 Rental_Id = re.Rental_Id,
                                 CarName=ca.CarName,
                                 CompanyName=cus.CompanyName
                             };
                return result.ToList();
                            
            }
            
        }
    }
}