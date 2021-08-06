using Core.Ultilities.Results;
using Entities.Concrate;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService : IServiceBase<Car>
    {
        IDataResult<List<CarDetailDto>> GetAllCarWithDetails();
        IDataResult<List<CarDetailDto>> GetByIdWithDetails(int id);
        IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId);       
    }
}