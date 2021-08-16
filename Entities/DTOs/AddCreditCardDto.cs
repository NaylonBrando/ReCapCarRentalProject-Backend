using Core.Entities;

namespace Entities.DTOs
{
    public class AddCreditCardDto : IDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string Cvv { get; set; }
    }


}
