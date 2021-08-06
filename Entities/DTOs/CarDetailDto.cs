using Core.Entities;
using Entities.Concrate;
using System.Collections.Generic;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public List<CarImage> CarImage { get; set; }
        public string FirstCarImage { get; set; }
        public string Description { get; set; }

    }
}