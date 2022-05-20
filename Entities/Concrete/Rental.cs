using Core.DataAccess;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Rental:IEntity
    {
        [Key]
        public int Rental_Id { get; set; }
        public int Model_Id { get; set; }
        public int Customer_Id { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
