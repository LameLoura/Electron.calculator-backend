using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using calculatorRestAPI.Services;
using calculatorRestAPI.Services.Entities;

namespace calculatorRestAPI.Controllers
{
    public class CalculatorProfileController : ApiController
    {
        // GET api/calculatorprofile
        public IEnumerable<string> Get( string userName )
        {
            CalculatorDTO result = Service.getService().getCalculatorData(userName);
            return new string[] { result.UserName, result.Operator, result.Result };
        }
    }
}