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
        public CreditCard GetByUser(int customerId)
        {
            using (var context = new ReCapProjectDbContext())
            {
                var result = from cu in context.Customers
                             join cd in context.CreditCards
                             on cu.CustomerId equals cd.CustomerId
                             where cu.CustomerId == customerId
                             select new CreditCard
                             {
                                 CustomerId = cu.CustomerId,
                                 CardNumberHash = cd.CardNumberHash,
                                 CardNumberSalt = cd.CardNumberSalt,
                                 ExpirationDateHash = cd.ExpirationDateHash,
                                 ExpirationDateSalt = cd.ExpirationDateSalt,
                                 CvvHash = cd.CvvHash,
                                 CvvSalt = cd.CvvSalt
                             };
                return result.FirstOrDefault();
            }
        }
    }

}
