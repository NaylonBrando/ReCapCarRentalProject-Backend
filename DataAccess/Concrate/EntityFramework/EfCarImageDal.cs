using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrate;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfCarImageDal : EfRepositoryBase<CarImage, ReCapProjectDbContext>, ICarImageDal
    {
    }
}