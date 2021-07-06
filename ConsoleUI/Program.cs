using Business.Concrate;
using DataAccess.Concrate.EntityFramework;
using Entities.Concrate;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------");
            //ColorManagerTestAllCRUDOperations(); //Çalıştı 2.05.2021
            Console.WriteLine("--------------------------------");
            Console.WriteLine("--------------------------------");
            //CarTest3AddCar(); //Çalıştı 2.05.2021
            //GetAllCarTest1();
            //AllCarDetailsTest1();
            Console.WriteLine("--------------------------------");
            //RentTest1();
            //ReturnTest();
        }

        private static void AllCarDetailsTest1()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result2 = carManager.GetAllCarWithDetails();
            foreach (var item in result2.Data)
            {
                Console.WriteLine(item.CarName + " " + item.BrandName + " " + item.ColorName + " " + item.DailyPrice);
            }
        }

        private static void ReturnTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal(), new CarManager(new EfCarDal()));
            rentalManager.Return(new Rental { Rental_Id = 1, CarId = 11, ReturnDate = "test" });
        }

        private static void RentTest1()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal(), new CarManager(new EfCarDal()));
            var result = rentalManager.Rental(new Rental { CarId = 11, CustomerId = 1, RentDate = DateTime.Now.ToString(), ReturnDate = default });
            Console.WriteLine(result.Message);
        }

        private static void ColorManagerTestAllCRUDOperations()
        {
            ColorManager colorManager1 = new ColorManager(new EfColorDal());
            colorManager1.Add(new Color { ColorName = "Requizm" });
            colorManager1.Update(new Color { ColorId = 7, ColorName = "Fenivia" });
            colorManager1.Delete(new Color { ColorId = 7 });
            //foreach (var item in colorManager1.GetAll())
            //{
            //    Console.WriteLine(item.ColorId + " " + item.ColorName);
            //}
        }

        private static void CarTest3AddCar()
        {
            CarManager carManager3 = new CarManager(new EfCarDal());
            carManager3.Add(new Car { BrandId = 1, CarName = "Arebe", ColorId = 2, DailyPrice = 11000, ModelYear = 1337, Description = "Test" });
        }

        private static void GetAllCarTest1()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            foreach (var item in result.Data)
            {
                Console.WriteLine(item.CarId + " " + item.BrandId + " " + item.ColorId
                    + " " + item.ModelYear + " " + item.DailyPrice + " " + item.Description);
            }
            //bool a = carManager.Add(new Car { DailyPrice = -333 });
        }
    }
}