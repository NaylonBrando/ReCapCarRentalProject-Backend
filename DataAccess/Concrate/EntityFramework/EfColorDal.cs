using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrate;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfColorDal : EfRepositoryBase<Color, ReCapProjectDbContext>, IColorDal
    {
    }
}