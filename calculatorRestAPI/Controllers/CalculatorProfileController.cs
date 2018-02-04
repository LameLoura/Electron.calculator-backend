using System.Web.Http;
using calculatorRestAPI.Models.DTOs;
using calculatorRestAPI.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace calculatorRestAPI.Controllers
{
    public class CalculatorProfileController : ApiController
    {
        /// <summary>
        /// Get calculator data for given <code>userName</code>
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        // GET api/calculatorprofile
        public CalculatorDTO Get( string userName )
        {
           CalculatorDTO result = Service.getService().getCalculatorData(userName);
            return result;
        }

        /// <summary>
        /// Insert/Update calculator data belong to the given <code>userName</code>
        /// </summary>
        /// <param name="jsonData">JSON string represents the data to save For example: {"paramA":"200","paramB":"300","result":"500","operator":"+"}</param>
        // PUT api/calculatorprofile
        public void Put( [FromBody]CalculatorDTO data)
        {
            //JObject JsonData = JObject.Parse(jsonData);
            //CalculatorDTO data = JsonData.ToObject<CalculatorDTO>();
            Service.getService().saveCalculatorData(data );
        }
    }
}