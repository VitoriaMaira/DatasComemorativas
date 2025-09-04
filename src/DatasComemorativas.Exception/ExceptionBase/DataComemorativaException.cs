namespace DataComemorativa.Exception.ExceptionBase
{
    public abstract class DataComemorativaException : SystemException
    {
        protected DataComemorativaException(string message) : base(message)
        {

        }

        public abstract int StatusCode { get; }
        public abstract List<string> GetErrors();
    }
}
