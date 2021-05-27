using Business.Abstract;
using Business.Constants;
using Core.Ultilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            if (customer.CompanyName.Length > 2)
            {
                _customerDal.Add(customer);
                return new SuccessResult("Müşteri başarıyla eklendi!");
            }
            return new ErrorResult("Müşteri ismi 2 karakterden küçük olamaz!");
        }

        public IResult Delete(Customer T)
        {
            //iş ve validate kodları
            _customerDal.Delete(T);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(p => p.CustomerId == id));
        }
        public IResult Update(Customer T)
        {
            _customerDal.Update(T);
            return new SuccessResult(Messages.SuccessUpdated);
        }

    }
}
