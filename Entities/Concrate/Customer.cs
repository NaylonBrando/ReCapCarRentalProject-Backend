using Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrate
{
    public class Customer : IEntity
    {
        //Gercek ve tüzel kisiler icin customeri ayirabilirdik(her ikisi icin ayri ayri tablo, entitiy, dataaccess, servis) ama simdilik böyle kalsin
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public string TaxNumber  { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentificationNumber  { get; set; }
    }
}