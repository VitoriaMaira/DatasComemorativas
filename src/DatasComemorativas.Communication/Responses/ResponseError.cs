using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataComemorativa.Communication.Responses
{
    public class ResponseError
    {
        public List<string> ErrorsMessages { get; set; }
        public ResponseError(string errorMessage)
        {
            ErrorsMessages = [errorMessage];
        }
        public ResponseError(List<string> errorMessage)
        {
            ErrorsMessages = errorMessage;
        }
    }
}
