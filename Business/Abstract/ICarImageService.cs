using Core.Ultilites.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetImagesByCarId(int id);
        IDataResult<CarImage> Get(int id);
        IResult Add(CarImage image, IFormFile file);
        IResult Delete(CarImage image);
        IResult Update(CarImage image,IFormFile file);
    }
}
