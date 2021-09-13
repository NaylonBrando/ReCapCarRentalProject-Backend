using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrate;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfFuelDal : EfRepositoryBase<Fuel, ReCapProjectDbContext>, IFuelDal
    {
    }
}