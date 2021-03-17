using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.InMemory.InMemory
{
    class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{BrandId=1, Id = 1, ModelYear = 2001, ColorId = 1, DailyPrice=50000, Description ="Simsek Mcqueen"},
                new Car{BrandId=2, Id = 1, ModelYear = 2003, ColorId = 1, DailyPrice=40000, Description ="Hudson Hornet"},
                new Car{BrandId=2, Id = 2, ModelYear = 2004, ColorId = 1, DailyPrice=40000, Description ="Back To Future"}

            };
        }   
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete=null;
            carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id); //Silinecek dizi nesnesinin referans adresini tutar.
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(p => p.BrandId == brandId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
