using Core.DataAccess; 
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car> 
    {
        CarDetailDto GetCarDetails(int id);
        List<CarDetailDto> GetAllCarDetails();
        List<CarDetailDto> GetAllCarDetailsByBrandId(int brandId);
        List<CarDetailDto> GetAllCarDetailsByColorId(int colorId);
    }
}
