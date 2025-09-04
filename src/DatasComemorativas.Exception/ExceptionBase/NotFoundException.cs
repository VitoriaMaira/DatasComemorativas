using System.Net;

namespace DataComemorativa.Exception.ExceptionBase
{
    public class NotFoundException : DataComemorativaException
    {
        public NotFoundException(string message) : base(message)
        {
        }

        public override int StatusCode => (int)HttpStatusCode.NotFound;

        public override List<string> GetErrors()
        {
            return [Message];
        }
    }
}
