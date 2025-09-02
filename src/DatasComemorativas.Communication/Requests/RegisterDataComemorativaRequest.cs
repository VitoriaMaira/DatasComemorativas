﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataComemorativa.Communication.Requests
{
    public class RegisterDataComemorativaRequest
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
    }
}
