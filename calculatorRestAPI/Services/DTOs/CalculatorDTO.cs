using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace calculatorRestAPI.Services.Entities
{
    public class CalculatorDTO
    {
        public string CustomerName { get; set; }
        public string UserName { get; set; }
        public string ParamA { get; set; }
        public string ParamB { get; set; }
        public string Result { get; set; }
        public string Operator { get; set; }
    }
}