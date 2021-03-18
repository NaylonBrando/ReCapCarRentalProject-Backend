using Business.Concrate;
using DataAccess.InMemory.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("------------InMemory-----------");
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Id + " " + item.BrandId + " " + item.ColorId
                    + " " + item.ModelYear + " " + item.DailyPrice + " " + item.Description);
            }
        }
    }
}
