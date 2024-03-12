using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Azure.WebJobs.Kusto;


namespace SignalRToKusto
{
    public class ConsumeSignalRMessages
    {
        [FunctionName("ConsumeSignalRMessages")]
        [return: Kusto(Database: "KustoDatabaseName",
                    TableName = "KustoTableName",
                    Connection = "KustoConnectionString")]
        public static string OnClientMessage(
    [   SignalRTrigger("Hub", "messages", "notificationMessage", "content", ConnectionStringSetting = "SignalRConnection")] string content, ILogger logger)
           {
            
            // logger.LogInformation($"C# Queue trigger function processed: {content}");
            return content;
        }
    }
}