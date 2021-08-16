using Business.Abstract;
using Core.Ultilities.Results;
using Core.Ultilities.Secuirty;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IDataResult<CreditCard> Add(AddCreditCardDto addCreditCardDto, string cardNumber, string expirationDate, string cvv)
        {
            byte[] cardNumberHash, cardNumberSalt, expirationDateHash, expirationDateSalt, cvvHash, cvvSalt;

            HashingHelper.CreateCardNumberHash(cardNumber, out cardNumberHash, out cardNumberSalt);
            HashingHelper.CreateExpirationDateHash(expirationDate, out expirationDateHash, out expirationDateSalt);
            HashingHelper.CreateCvvHash(cvv, out cvvHash, out cvvSalt);

            var card = new CreditCard
            {
                Id = addCreditCardDto.Id,
                CustomerId = addCreditCardDto.CustomerId,
                CardNumberHash = cardNumberHash,
                CardNumberSalt = cardNumberSalt,
                CvvHash = cvvHash,
                CvvSalt = cvvSalt,
                ExpirationDateHash = expirationDateHash,
                ExpirationDateSalt = expirationDateSalt
            };
            _creditCardDal.Add(card);
            return new SuccessDataResult<CreditCard>(card, "Eklendi");
        }

        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult();
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll());
        }

        public IDataResult<CreditCard> GetById(int id)
        {
            return new SuccessDataResult<CreditCard>(_creditCardDal.Get(c => c.Id == id));
        }

        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult();
        }

        public IDataResult<CreditCard> CheckTheCreditCard(PaymentDto paymentDto)
        {
            var getCardToCheck = _creditCardDal.GetByUser(paymentDto.CustomerId);
            //Burası parametre olarak girilen ödeme bilgisiyle veritabanındaki CreditCards tablosundan cekilen ilgili salt ve hash binary arraylerinin karsilastirildiklari yer
            var cardNumberStatus = HashingHelper.VerifyCardNumberHash(paymentDto.CardNumber, getCardToCheck.CardNumberHash, getCardToCheck.CardNumberSalt);
            var expirationDateStatus = HashingHelper.VerifyExpirationDateHash(paymentDto.ExpirationDate, getCardToCheck.ExpirationDateHash, getCardToCheck.ExpirationDateSalt);
            var cvvStatus = HashingHelper.VerifyCvvHash(paymentDto.Cvv, getCardToCheck.CvvHash, getCardToCheck.CvvSalt);

            if (!cardNumberStatus || !expirationDateStatus || !cvvStatus)
            {
                return new ErrorDataResult<CreditCard>("Kart bilgileri hatalı.");
            }

            return new SuccessDataResult<CreditCard>(getCardToCheck, "Ödeme işlemi başarılı.");
        }

        public IDataResult<CreditCard> GetByUser(int userId)
        {
            return new SuccessDataResult<CreditCard>(_creditCardDal.GetByUser(userId));
        }
    }
}
