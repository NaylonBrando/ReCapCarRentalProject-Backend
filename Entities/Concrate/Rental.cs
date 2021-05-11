using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrate
{
    public class Rental:IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Rental_Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public string RentDate { get; set; }
        public string ReturnDate { get; set; }
        

    }
}
