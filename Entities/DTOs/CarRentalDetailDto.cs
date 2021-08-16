using Core.Entities;
using System;

namespace Entities.DTOs
{
    public class CarRentalDetailDto:IDto
    {
        public int Rental_Id { get; set; }
        public string BrandName { get; set; }
        public string CarName { get; set; }//front-end kısmında 
        public string CompanyName { get; set; }//CustomerName
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}