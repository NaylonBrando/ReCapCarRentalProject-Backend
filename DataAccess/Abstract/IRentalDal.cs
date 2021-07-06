using Core.DataAccess;
using Entities.Concrate;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        List<CarRentalDetailDto> GetCarRentalDetails();
    }
}