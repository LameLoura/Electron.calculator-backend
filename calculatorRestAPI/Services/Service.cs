using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using calculatorRestAPI.Models.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace calculatorRestAPI.Services
{
    public class Service
    {
        private static Service thisService;
        private static readonly string tableName = "CalculatorData";

        AmazonDynamoDBConfig clientConfig = new AmazonDynamoDBConfig();
        AmazonDynamoDBClient client = new AmazonDynamoDBClient( new AmazonDynamoDBConfig());

       public static Service getService()
       {
            if ( thisService == null )
            {
                thisService = new Service();
            }
            return thisService;
       }

        public CalculatorDTO getCalculatorData( string userName )
        {
            Table table = Table.LoadTable(client, tableName);
            QueryFilter filter = new QueryFilter("UserID", QueryOperator.Equal, userName );

            CalculatorDTO answer = new CalculatorDTO();
            Search search = table.Query(filter);
            List<Document> queryResult = search.GetNextSet();
            if(queryResult.Count > 0 && queryResult.FirstOrDefault() != null )
            {
                Document output = queryResult.FirstOrDefault();
                answer.ParamA = output["paramA"];
                answer.ParamB = output["paramB"];
                answer.Operator = output["operator"];
                answer.Result = output["result"];
            }
            return answer;
        }

        public void saveCalculatorData(CalculatorDTO data)
        {
            Table table = Table.LoadTable(client, tableName);

            Document book = new Document();
            book["UserID"] = data.UserID;
            book["paramA"] = data.ParamA;
            book["paramB"] = data.ParamB;
            book["operator"] = data.Operator;
            book["result"] = data.Result;

            table.PutItem(book);
        }

    }
}