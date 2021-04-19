using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfCarDal : EfRepositoryBase<Car, ReCapProjectDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectDbContext context = new ReCapProjectDbContext())
            {
                var result = from ca in context.Cars
                             join b in context.Brands
                             on ca.BrandId equals b.BrandId
                             join cl in context.Colors
                             on ca.ColorId equals cl.ColorId
                             select new CarDetailDto
                             {
                                 CarName = ca.CarName,
                                 ColorName = cl.ColorName,
                                 BrandName = b.BrandName,
                                 DailyPrice = ca.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}