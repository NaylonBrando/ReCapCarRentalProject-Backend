using Core.DataAccess;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
        Customer GetLastCustomerByUserId(Expression<Func<Customer, bool>> filter);
    }
}