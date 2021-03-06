using Core.Entities;
using Entities.Concrete;
using Entities.DTOs.RentalDto;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        List<RentalDetailDto> GetRentalDetails();
    }
}
