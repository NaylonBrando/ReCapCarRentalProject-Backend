using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrate
{
    public class RentalCheck:IEntity
    {
        public string rentDate { get; set; }
        public string returnDate { get; set; }
        public int carId { get; set; }
    }
}
