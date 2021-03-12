using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramwork
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectCarsContext>, IRentalDal
    {
        public RentalDto GetRentalDto(int id)
        {
            using (ReCapProjectCarsContext context = new ReCapProjectCarsContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join col in context.Colors
                             on c.ColorId equals col.ColorId
                             join cus in context.Customers
                             on r.CustomerId equals cus.Id
                             join user in context.Users
                             on cus.UserId equals user.Id
                             select new RentalDto
                             {
                                 Id = r.Id,
                                 BrandName = b.CarBrand,
                                 ColorName = col.CarColor,
                                 CompanyName = cus.CompanyName,
                                 DailyPrice = c.DailyPrice,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };

                return result.SingleOrDefault(i=>i.Id==id);
            }
        }

        public List<RentalDto> GetRentalDtos()
        {
            using (ReCapProjectCarsContext context = new ReCapProjectCarsContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join col in context.Colors
                             on c.ColorId equals col.ColorId
                             join cus in context.Customers
                             on r.CustomerId equals cus.Id
                             join user in context.Users
                             on cus.UserId equals user.Id
                             select new RentalDto
                             {
                                 Id = r.Id,
                                 BrandName = b.CarBrand,
                                 ColorName = col.CarColor,
                                 CompanyName = cus.CompanyName,
                                 DailyPrice = c.DailyPrice,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };

                return result.ToList();
            }
        }
    }
}
