using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataComemorativa.Exception.ExceptionBase
{
    public class ErrorOnValidationException : DataComemorativaException
    {
        public List<string> Errors { get; set; }

        public ErrorOnValidationException(List<string> errorsMessages)
        {
            Errors = errorsMessages;
        }
    }
}
