using Core.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Model:IEntity
    {
        [Key]
        public int Model_Id { get; set; }
        public int Brand_Id { get; set; }
        public int CarTypeDetail_Id { get; set; }
        public int Color_Id { get; set; }
        public string Model_Name { get; set; }
        public decimal Daily_Price { get; set; }
        public short Model_Year { get; set; }
        public string Description { get; set; }
    }
}
