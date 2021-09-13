using Core.DataAccess;
using Entities.Concrate;

namespace DataAccess.Abstract
{
    public interface ICreditCardDal : IEntityRepository<CreditCard>
    {
        CreditCard GetByCustomerId(int userId);
    }
}
