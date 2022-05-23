using Core.DataAccess;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Rental:IEntity
    {
        [Key]
        public int RentalId { get; set; }
        public int ModelId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
