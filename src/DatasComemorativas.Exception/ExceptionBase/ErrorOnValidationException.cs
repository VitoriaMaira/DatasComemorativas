namespace DataComemorativa.Exception.ExceptionBase
{
    public class ErrorOnValidationException : DataComemorativaException
    {
        public override int StatusCode => 400; 

        public override List<string> GetErrors() => Errors;

        public List<string> Errors { get; set; }

        public ErrorOnValidationException(List<string> errorsMessages) : base("Validation error")
        {
            Errors = errorsMessages;
        }
    }
}