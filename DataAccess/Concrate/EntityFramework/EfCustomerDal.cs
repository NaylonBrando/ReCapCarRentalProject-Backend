using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Linq.Expressions;
using System.Linq;
using System.Collections.Generic;
using Entities.DTOs;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfCustomerDal : EfRepositoryBase<Customer, ReCapProjectDbContext>, ICustomerDal
    {

        public Customer GetLastCustomerByUserId(Expression<Func<Customer, bool>> filter)
        {
            using (ReCapProjectDbContext context = new ReCapProjectDbContext())
            {
                return context.Set<Customer>().ToList().LastOrDefault();
            }
        }


    }
}