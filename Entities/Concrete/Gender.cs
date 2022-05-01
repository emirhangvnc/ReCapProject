using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Gender:IEntity
    {
        public int Gender_Id { get; set; }
        public string Gender_Name { get; set; }
    }
}
