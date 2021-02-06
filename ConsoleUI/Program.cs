using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramwork;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.DailyPrice);
            }


            //carManager.Add(new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 180, ModelYear = 2010, CarDescription = "32 Beygir,sağlam" });
            //carManager.Add(new Car { Id = 2, BrandId = 3, ColorId = 1, DailyPrice = 279, ModelYear = 2011, CarDescription = "40 Beygir,sağlam" });
            //carManager.Add(new Car { Id = 3, BrandId = 2, ColorId = 3, DailyPrice = 350, ModelYear = 2013, CarDescription = "50 Beygir,sağlam" });
            //carManager.Add(new Car { Id = 4, BrandId = 1, ColorId = 2, DailyPrice = 499, ModelYear = 2019, CarDescription = "60 Beygir,sağlam" });
            //carManager.Add(new Car { Id = 5, BrandId = 2, ColorId = 3, DailyPrice = 109, ModelYear = 2003, CarDescription = "18 Beygir,sağlam" });

            //carManager.Delete(new Car {Id=2});

            Car car1 =carManager.Get(3);
            Console.WriteLine(car1.CarDescription);

            List<Car> cars = carManager.GetAll();

            foreach (var car in cars)
            {
                Console.WriteLine(car.Id);
            }

            //colorManager.Add(new Color {ColorId=1,CarColor="Siyah" });
            //colorManager.Add(new Color { ColorId = 2, CarColor = "Beyaz" });
            //colorManager.Add(new Color { ColorId = 3, CarColor = "Kırmızı" });
            //colorManager.Add(new Color { ColorId = 4, CarColor = "Mavi" });

            //colorManager.Delete(new Color {ColorId=4 });

            //colorManager.Update(new Color {ColorId=3,CarColor="Sarı" });

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.CarColor);
            }

            var a = colorManager.Get(3);
            Console.WriteLine(a.CarColor);

            foreach (var car in carManager.GetByBrandId(1))
            {
                Console.WriteLine(car.CarDescription);
            }

            foreach (var car in carManager.GetByColorId(1))
            {
                Console.WriteLine(car.CarDescription);
            }

        }
    }
}
