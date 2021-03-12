﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IDataResult<Rental> Get(int id);
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentalDto>> GetAllRentalDtos();
        IDataResult<RentalDto> GetRentalDto(int id);
    }
}
