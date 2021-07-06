using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrate;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfBrandDal : EfRepositoryBase<Brand, ReCapProjectDbContext>, IBrandDal
    {
    }
}