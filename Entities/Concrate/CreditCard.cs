using Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrate
{
    public class CreditCard : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] CardNumberSalt { get; set; }
        public byte[] CardNumberHash { get; set; }
        public byte[] ExpirationDateSalt { get; set; }
        public byte[] ExpirationDateHash { get; set; }
        public byte[] CcvSalt { get; set; }
        public byte[] CcvHash { get; set; }
    }
}
