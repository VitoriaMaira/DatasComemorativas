using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataComemorativa.Communication.Responses
{
    public class ResponseRegisterDataComemorativa
    {
        public string Message { get; set; }

        public ResponseRegisterDataComemorativa(string message)
        {
            Message = message;
        }
    }
    
}
