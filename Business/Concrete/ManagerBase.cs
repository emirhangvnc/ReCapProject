using AutoMapper;

namespace Business.Concrete
{
    public class ManagerBase
    {
        protected IMapper _mapper;
        public ManagerBase(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
