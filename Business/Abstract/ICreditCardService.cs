using Core.Ultilities.Results;
using Entities.Concrate;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IDataResult<List<CreditCard>> GetAll();
        IDataResult<CreditCard> GetById(int id);
        IDataResult<CreditCard> Add(AddCreditCardDto addCreditCardDto, string cardNumber, string expirationDate, string cvv);
        IResult Update(CreditCard creditCard);
        IResult Delete(CreditCard creditCard);
        IDataResult<CreditCard> CheckTheCreditCard(PaymentDto paymentDto);
        IDataResult<CreditCard> GetByCustomerId(int customerId);
    }

}
