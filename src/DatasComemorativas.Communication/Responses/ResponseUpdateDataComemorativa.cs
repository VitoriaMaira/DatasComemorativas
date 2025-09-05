using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataComemorativa.Application.UseCases.DataComemorativa.Update
{
    public class ResponseUpdateDataComemorativa
    {
        public int Id { get; set; }
        public string Message { get; set; }

        public ResponseUpdateDataComemorativa(int id, string message)
        {
            Id = id;
            Message = message;
        }
    }
}

