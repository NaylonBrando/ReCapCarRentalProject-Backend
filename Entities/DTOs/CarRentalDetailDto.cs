namespace Entities.DTOs
{
    public class CarRentalDetailDto
    {
        public int Rental_Id { get; set; }
        public string ColorName { get; set; }
        public string CarName { get; set; }
        public string CompanyName { get; set; }//CustomerName
        public string RentDate { get; set; }
        public string ReturnDate { get; set; }
    }
}