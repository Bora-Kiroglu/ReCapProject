using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramwork
{
    public class EfCarDal : EfEntityRepositoryBase<Car,ReCapProjectCarsContext>, ICarDal
    {
        public CarDetailDto GetCarDetails(int id) 
        {
            using (ReCapProjectCarsContext context = new ReCapProjectCarsContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join col in context.Colors
                             on c.ColorId equals col.ColorId
                             join i in context.CarImages
                             on c.Id equals i.CarId
                             select new CarDetailDto {Id = c.Id,CarDescription = c.CarDescription,CarBrand = b.CarBrand, CarColor = col.CarColor, DailyPrice = c.DailyPrice, ImagePath = i.ImagePath  };

                return result.SingleOrDefault(p => p.Id == id);
            }
        }

        public List<CarDetailDto> GetAllCarDetails() 
        {
            using (ReCapProjectCarsContext context = new ReCapProjectCarsContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join col in context.Colors
                             on c.ColorId equals col.ColorId
                             join i in context.CarImages
                             on c.Id equals i.CarId
                             select new CarDetailDto { Id=c.Id,CarDescription = c.CarDescription, CarBrand = b.CarBrand, CarColor = col.CarColor, DailyPrice = c.DailyPrice,ImagePath = i.ImagePath };

                return result.ToList();
            }
        }

        public List<CarDetailDto> GetAllCarDetailsByBrandId(int brandId)
        {
            using (ReCapProjectCarsContext context = new ReCapProjectCarsContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join col in context.Colors
                             on c.ColorId equals col.ColorId
                             join i in context.CarImages
                             on c.Id equals i.CarId
                             //where c.BrandId == brandId
                             select new CarDetailDto { Id = c.Id, CarDescription = c.CarDescription, CarBrand = b.CarBrand, CarColor = col.CarColor, DailyPrice = c.DailyPrice, ImagePath = i.ImagePath };

                return result.ToList();
            }
        }

        public List<CarDetailDto> GetAllCarDetailsByColorId(int colorId)
        {
            using (ReCapProjectCarsContext context = new ReCapProjectCarsContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join col in context.Colors
                             on c.ColorId equals col.ColorId
                             join i in context.CarImages
                             on c.Id equals i.CarId
                             where c.ColorId == colorId
                             select new CarDetailDto { Id = c.Id, CarDescription = c.CarDescription, CarBrand = b.CarBrand, CarColor = col.CarColor, DailyPrice = c.DailyPrice, ImagePath = i.ImagePath };

                return result.ToList();
            }
        }

    }
}
