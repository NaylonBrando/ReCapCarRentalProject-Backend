using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrate
{
    public class Payment : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CardId { get; set; }
        public DateTime Date { get; set; }
        public int TotalPayment { get; set; }
        
    }
}
