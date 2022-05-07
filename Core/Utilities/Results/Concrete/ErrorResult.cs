using Core.Utilities.Results.Concrete.BaseConcrete;

namespace Core.Utilities.Results.Concrete
{
    public class ErrorResult:Result
    {
        public ErrorResult(string message) : base(false, message)
        {

        }
        public ErrorResult() : base(false)
        {

        }
    }
}
