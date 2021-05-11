using Core.Ultilities.Results;
using Entities.Concrate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface IRentalService
    {
        //Kiralama kodları burada olacak
        //Arabanın müsait olup olmama durumu, renet listesinde müsait olmama durumu
        //Hangi fonk?

        IDataResult<List<Rental>> GetAll();
        IDataResult<List<Rental>> GetRentalById(int id);
        IDataResult<List<CarRentalDetailDto>> GetRentalDetails();
        IResult Rental(Rental rental);
        IResult UpdateRental(Rental rental);
        IResult Return(Rental rental);
    }
}
