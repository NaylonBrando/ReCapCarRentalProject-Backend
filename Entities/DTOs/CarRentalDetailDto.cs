using Core.Entities;

namespace Entities.DTOs
{
    public class CarRentalDetailDto:IDto
    {
        public int Rental_Id { get; set; }
        public string BrandName { get; set; }
        public string CarName { get; set; }//front-end kısmında 
        public string CompanyName { get; set; }//CustomerName
        public string RentDate { get; set; }
        public string ReturnDate { get; set; }
    }
}