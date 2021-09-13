using Core.Ultilities.Results;
using Entities.Concrate;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();

        IDataResult<Customer> GetById(int id);

        IDataResult<Customer> GetLastCustomerByUserId(int id);

        IResult Add(Customer customer);

        IResult Delete(Customer customer);

        IResult Update(Customer customer);
    }
}