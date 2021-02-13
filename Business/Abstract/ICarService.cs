using Core.Ultilites.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> Get(int id);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<Car>> GetByBrandId(int id);
        IDataResult<List<Car>> GetByColorId(int id);
        IDataResult<CarDetailDto> GetCarDetails(int id);
        IDataResult<List<CarDetailDto>> GetAllCarDetails();
    }
}
