using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfRentalDal : EfRepositoryBase<Rental, ReCapProjectDbContext>, IRentalDal
    {
        public List<CarRentalDetailDto> GetCarRentalDetails()
        {
            throw new NotImplementedException();
        }

    }
}
