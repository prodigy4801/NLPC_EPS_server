using FluentValidation.Results;

namespace NLPC_EPS_server.Application.Exceptions
{
    public class NotFoundExceptions : Exception
    {
        public NotFoundExceptions(string name, object key) : base($"{name} ({key}) was not Found")
        {

        }
    }
}
