using Core.Ultilities.Results;
using Entities.Concrate;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Abstract
{
    //Base inferfaceden ayirmamin sebebi buradaki metodların en ez 2 parametre almasi
    public interface ICarImageService
    {
        IResult Add(IFormFile file, CarImage carImage);

        IResult Delete(CarImage carImage);

        IResult Update(IFormFile file, CarImage carImage);

        IDataResult<CarImage> Get(int carImageid);

        IDataResult<List<CarImage>> GetAll();

        IDataResult<List<CarImage>> GetImagesByCarId(int carId);
    }
}