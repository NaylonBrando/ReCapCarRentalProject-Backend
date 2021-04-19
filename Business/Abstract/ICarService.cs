using Entities.Concrate;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public  interface ICarService
    {
        List<Car> GetAll();

        List<Car> GetCarsByBrandId(int id);

        List<Car> GetCarsByColorId(int id);

        bool Add(Car car);
        List<CarDetailDto> GetCarDetails();
    }
}