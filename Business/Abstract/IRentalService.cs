using Core.Ultilities.Results;
using Entities.Concrate;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRentalService
    {
        //Kiralama kodları burada olacak
        //Arabanın müsait olup olmama durumu, renet listesinde müsait olmama durumu
        //Hangi fonk?

        IDataResult<List<Rental>> GetAll();

        IDataResult<List<Rental>> GetRentalById(int id);

        IDataResult<List<CarRentalDetailDto>> GetAllRentalsWithDetails();

        IResult Rent(Rental rental);

        IResult UpdateRental(Rental rental);

        IResult Return(Rental rental);

        IDataResult<Rental> GetLastRentalById(int id);

        //IResult AddTransactionalTest(Rental rental);
    }
}