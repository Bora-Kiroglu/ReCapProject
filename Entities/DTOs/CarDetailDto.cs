using Core.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto:IDto
    {
        public int Id { get; set; }
        public string CarDescription { get; set; }
        public string CarBrand { get; set; }
        public string CarColor { get; set; }
        public decimal DailyPrice { get; set; }
    }
}
