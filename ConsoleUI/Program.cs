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

            CarTest1();
            Console.WriteLine("--------------------------------");
            CarTest2();

        }

        private static void CarTest2()
        {
            CarManager carManager2 = new CarManager(new EfCarDal());
            foreach (var item in carManager2.GetCarDetails())
            {
                Console.WriteLine("{0} {1} {2}", item.ColorName, item.BrandName, item.CarName); //Neden 1 ve 2 arasında bu kadar bosluk var
            }
        }

        private static void CarTest1()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.CarId + " " + item.BrandId + " " + item.ColorId
                    + " " + item.ModelYear + " " + item.DailyPrice + " " + item.Description);
            }
            bool a = carManager.Add(new Car { DailyPrice = -333 });
        }
    }
}