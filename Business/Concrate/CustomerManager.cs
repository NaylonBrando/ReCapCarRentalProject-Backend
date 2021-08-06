using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Ultilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using System.Collections.Generic;

namespace Business.Concrate
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Add(Customer customer)
        {
            if (customer.CompanyName.Length > 2)
            {
                _customerDal.Add(customer);
                return new SuccessResult("Müşteri başarıyla eklendi!");
            }
            return new ErrorResult("Müşteri ismi 2 karakterden küçük olamaz!");
        }

        //[ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Delete(Customer T)
        {
            //iş ve validate kodları
            _customerDal.Delete(T);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }
        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(p => p.CustomerId == id));
        }   
    }
}