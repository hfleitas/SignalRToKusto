using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.Kusto;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;

namespace SignalRToKusto
{
    public class ConsumeSignalRMessages
    {
        IConfiguration _configuration;
        public ConsumeSignalRMessages(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        HubConnection connection = null;
        [FunctionName("TrimbleNotificationToKusto24")]
        public void TrimbleNotificationToKusto(
        [TimerTrigger("* */5 * * * *", RunOnStartup = true)] TimerInfo timer, ILogger logger,
        [Kusto(Database: "%KustoDB%", TableName = "%KustoTable%", Connection = "KustoConnectionString")] IAsyncCollector<string> notifications)
        {
            if (connection == null)
            {
                string connectionString = _configuration.GetValue<string>("SignalRConnection");
                // Note: This will print the API Key as well!
                logger.LogTrace($"Initialized hub connection at : {DateTime.Now} for {connectionString}");
                connection = new HubConnectionBuilder()
                    .WithUrl(connectionString)
                    .WithAutomaticReconnect(new[] { TimeSpan.FromSeconds(5) })
                    .Build();
            }
            logger.LogTrace($"Timer trigger function executed at: {DateTime.UtcNow}");
            // Make this configurable too!
            string methodName = _configuration.GetValue<string>("MethodName");
            connection.On<dynamic>(methodName, async (message) =>
            {
                try
                {
                    logger.LogTrace($"Received message: {message}");
                    notifications.AddAsync(message.ToString());
                    await notifications.FlushAsync();
                }
                catch (Exception ex)
                {
                    await connection.StopAsync();
                    logger.LogError($"Closing connection as there is an error ingesting to Kusto {ex}");
                }
            });
            if (connection.State != HubConnectionState.Connected)
            {
                logger.LogInformation($"Connection state is {connection.State}, starting hub connection at : {DateTime.UtcNow}");
                connection.StartAsync();
            }
        }
    }
}