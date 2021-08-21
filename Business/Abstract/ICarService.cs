using Core.Ultilities.Results;
using Entities.Concrate;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);
        IResult Add(Car T);
        IResult Delete(Car T);
        IResult Update(Car T);
        IDataResult<List<CarDetailDto>> GetAllCarWithDetails();
        IDataResult<CarDetailDto> GetByIdWithDetails(int id);
        IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId);       
    }
}