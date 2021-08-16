using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Text;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfPaymentDal : EfRepositoryBase<Payment, ReCapProjectDbContext>, IPaymentDal
    {
    }

}
