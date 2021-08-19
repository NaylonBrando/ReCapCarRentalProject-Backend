using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfCarDal : EfRepositoryBase<Car, ReCapProjectDbContext>, ICarDal
    {


        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
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
                                 CarId = ca.CarId,
                                 BrandId = ca.BrandId,
                                 ColorId = ca.ColorId,
                                 CarName = ca.CarName,
                                 ColorName = cl.ColorName,
                                 BrandName = b.BrandName,
                                 ModelYear = ca.ModelYear,
                                 DailyPrice = ca.DailyPrice,
                                 Description=ca.Description,
                                 FirstCarImage = (from i in context.CarImages
                                                  where (ca.CarId == i.CarId)
                                                  select i.ImagePath).FirstOrDefault()
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }


        }

        public List<CarDetailDto> GetOneCarDetails(Expression<Func<CarDetailDto, bool>> filter)
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
                                 CarId = ca.CarId,
                                 BrandId = ca.BrandId,
                                 ColorId = ca.ColorId,
                                 CarName = ca.CarName,
                                 ColorName = cl.ColorName,
                                 BrandName = b.BrandName,
                                 ModelYear = ca.ModelYear,
                                 DailyPrice = ca.DailyPrice,
                                 Description = ca.Description,
                                 CarImage = (from i in context.CarImages
                                             where (ca.CarId == i.CarId)
                                             select new CarImage { CarId = i.CarId, Date = i.Date, Id = i.Id, ImagePath = i.ImagePath }).ToList()

                             };
                return result.Where(filter).ToList();
            }
        }
    }
}