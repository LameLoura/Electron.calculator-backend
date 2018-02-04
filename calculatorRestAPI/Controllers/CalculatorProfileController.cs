using System.Web.Http;
using calculatorRestAPI.Models.DTOs;
using calculatorRestAPI.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace calculatorRestAPI.Controllers
{
    public class CalculatorProfileController : ApiController
    {
        // GET api/calculatorprofile
        public string Get( string userName )
        {
           CalculatorDTO result = Service.getService().getCalculatorData(userName);
            return JsonConvert.SerializeObject(result);
        }

        // PUT api/calculatorprofile
        public void Put( string userName, [FromBody]string jsonData)
        {
            JObject JsonData = JObject.Parse(jsonData);
            CalculatorDTO data = JsonData.ToObject<CalculatorDTO>();
            data.UserID = userName;
            Service.getService().saveCalculatorData(data );
        }
    }
}