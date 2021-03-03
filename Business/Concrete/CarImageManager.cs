using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage image, IFormFile file)
        {
            var result = BusinessRules.Run(CheckImageLimitExceed(image.CarId));
            if (result !=null)
            {
                return result;
            }

            image.ImagePath = FileHelper.Add(file);
            image.Date = DateTime.Now;
            _carImageDal.Add(image);

            return new SuccessResult();
        }

        public IResult Delete(CarImage image)
        {
            var result = _carImageDal.Get(c=>c.Id==image.Id);
            FileHelper.Delete(result.ImagePath);
            _carImageDal.Delete(image);
            return new SuccessResult();
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c=>c.Id==id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id));
        }

        public IResult Update(CarImage image, IFormFile file)
        {
            image.ImagePath = FileHelper.Update(_carImageDal.Get(c=>c.Id==image.Id).ImagePath,file);
            image.Date = DateTime.Now;
            _carImageDal.Update(image);

            return new SuccessResult();

        }

        private IResult CheckImageLimitExceed(int carId)
        {
            var imageCount = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (imageCount>=5)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        //private List<CarImage> CheckIfImageNull(int id)
        //{
        //    string path = @"\Images\noPhoto.png";
        //    var result = _carImageDal.GetAll(c=>c.CarId==id);
        //    if (result.Count>0)
        //    {
        //        return new List<CarImage> { new CarImage{ CarId = id, Date = DateTime.Now, ImagePath = path } };
        //    }

        //    return result;
        //}
    }
}
