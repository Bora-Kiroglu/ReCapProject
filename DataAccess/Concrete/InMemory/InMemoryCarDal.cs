using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars = new List<Car>() 
        {
            new Car {Id=1, BrandId=1, ColorId=1, DailyPrice=180, ModelYear = 2010, CarDescription="32 Beygir,sağlam"},
            new Car {Id=2, BrandId=3, ColorId=1, DailyPrice=279, ModelYear = 2011, CarDescription="40 Beygir,sağlam"},
            new Car {Id=3, BrandId=2, ColorId=3, DailyPrice=350, ModelYear = 2013, CarDescription="50 Beygir,sağlam"},
            new Car {Id=4, BrandId=1, ColorId=2, DailyPrice=499, ModelYear = 2019, CarDescription="60 Beygir,sağlam"},
            new Car {Id=5, BrandId=2, ColorId=3, DailyPrice=109, ModelYear = 2003, CarDescription="18 Beygir,sağlam"}
        };


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            //foreach (var c in _cars)
            //{
            //    if (car==c)
            //    {
            //        _cars.Remove(c);
            //    }
            //}

            Car carToDelete = _cars.SingleOrDefault(c => c.Id==car.Id);
            _cars.Remove(carToDelete);

        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int carId)
        {
            return _cars.SingleOrDefault(c=> c.Id==carId);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.CarDescription = car.CarDescription;
        }
    }
}
