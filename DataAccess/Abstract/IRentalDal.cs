using Core.DataAccess;
using Entities.Concrate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        List<CarRentalDetailDto> GetAllRentalsWithDetails();
        Rental GetLastRentalById(int id);
        Rental CheckRentalDate(RentalCheck rental);
    }
}