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
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            //TestGetAll(carManager);

            //AddCar(carManager);

            //CarDelete(carManager);

            //GetCar(carManager);

            //ColorAdd(colorManager);

            //ColorDelete(colorManager);

            //ColorUpdate(colorManager);

            //GetColor(colorManager);

            //GetByBrandId(carManager);

            //GetByColorId(carManager);

            //GetCarDetails(carManager);

            //GetAllCarDetails(carManager);

            AddRental(rentalManager);


        }

        private static void AddRental(RentalManager rentalManager)
        {
            DateTime tarih1 = new DateTime(2021, 02, 07, 12, 20, 00);
            DateTime tarih2 = new DateTime(2021, 02, 15, 12, 20, 00);
            var rental1 = new Rental { CarId = 2, CustomerId = 1, RentDate = tarih1, ReturnDate = tarih2 };
            Console.WriteLine(rentalManager.Add(rental1).Message);
        }

        private static void GetAllCarDetails(CarManager carManager)
        {
            var result3 = carManager.GetAllCarDetails();

            foreach (var car in result3.Data)
            {
                Console.WriteLine(car.CarColor + " " + car.CarBrand);
            }
        }

        private static void GetCarDetails(CarManager carManager)
        {
            var x = carManager.GetCarDetails(2);
            Console.WriteLine(x.Data.CarDescription + " " + x.Data.CarBrand + " " + x.Data.CarColor);
        }

        private static void GetByColorId(CarManager carManager)
        {
            var result2 = carManager.GetByColorId(1);

            foreach (var car in result2.Data)
            {
                Console.WriteLine(car.CarDescription);
            }
            
        }

        private static void GetByBrandId(CarManager carManager)
        {
            var result1 = carManager.GetByBrandId(1);

            foreach (var car in result1.Data)
            {
                Console.WriteLine(car.CarDescription);
            }
        }

        private static void GetColor(ColorManager colorManager)
        {
            var a = colorManager.Get(3);
            Console.WriteLine(a.Data.CarColor);
        }

        private static void ColorUpdate(ColorManager colorManager)
        {
            colorManager.Update(new Color { ColorId = 3, CarColor = "Sarı" });
        }

        private static void ColorDelete(ColorManager colorManager)
        {
            colorManager.Delete(new Color { ColorId = 4 });
        }

        private static void ColorAdd(ColorManager colorManager)
        {
            //colorManager.Add(new Color { ColorId = 1, CarColor = "Siyah" });
            //colorManager.Add(new Color { ColorId = 2, CarColor = "Beyaz" });
            //colorManager.Add(new Color { ColorId = 3, CarColor = "Kırmızı" });
            //Console.WriteLine(colorManager.Add(new Color { CarColor = "Turuncu" }).Message);
            
        }

        private static void GetCar(CarManager carManager)
        {
            var car1 = carManager.Get(3);
            Console.WriteLine(car1.Data.CarDescription);
        }

        private static void CarDelete(CarManager carManager)
        {
            carManager.Delete(new Car { Id = 2 });
        }

        private static void AddCar(CarManager carManager)
        {
            carManager.Add(new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 180, ModelYear = 2010, CarDescription = "32 Beygir,sağlam" });
            carManager.Add(new Car { Id = 2, BrandId = 3, ColorId = 1, DailyPrice = 279, ModelYear = 2011, CarDescription = "40 Beygir,sağlam" });
            carManager.Add(new Car { Id = 3, BrandId = 2, ColorId = 3, DailyPrice = 350, ModelYear = 2013, CarDescription = "50 Beygir,sağlam" });
            carManager.Add(new Car { Id = 4, BrandId = 1, ColorId = 2, DailyPrice = 499, ModelYear = 2019, CarDescription = "60 Beygir,sağlam" });
            carManager.Add(new Car { Id = 5, BrandId = 2, ColorId = 3, DailyPrice = 109, ModelYear = 2003, CarDescription = "18 Beygir,sağlam" });
        }

        private static void TestGetAll(CarManager carManager)
        {
            var test = carManager.GetAll();

            foreach (var car in test.Data)
            {
                Console.WriteLine(car.DailyPrice);
            }
        }
    }
}
