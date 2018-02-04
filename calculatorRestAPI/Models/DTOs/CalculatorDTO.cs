using System.Runtime.Serialization;

namespace calculatorRestAPI.Models.DTOs
{
    [DataContract]
    public class CalculatorDTO
    {
        [DataMember(Name = "userName")]
        public string UserName { get; set; }

        [DataMember(Name = "paramA")]
        public string ParamA { get; set; }

        [DataMember(Name = "paramB")]
        public string ParamB { get; set; }

        [DataMember(Name = "result")]
        public string Result { get; set; }

        [DataMember(Name = "operator")]
        public string Operator { get; set; }
    }
}