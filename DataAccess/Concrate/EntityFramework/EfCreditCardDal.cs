using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfCreditCardDal : EfRepositoryBase<CreditCard, ReCapProjectDbContext>, ICreditCardDal
    {
        public CreditCard GetByCustomerId(int customerId)
        {
            using (var context = new ReCapProjectDbContext())
            {
                var result = from cu in context.Customers
                             join cd in context.CreditCards
                             on cu.Id equals cd.CustomerId
                             where cu.Id == customerId
                             select new CreditCard
                             {
                                 Id = cd.Id,
                                 FirstName = cu.FirstName,
                                 LastName = cu.LastName,
                                 CustomerId = cu.Id,
                             };
                return result.FirstOrDefault();
            }
        }
    }

}
