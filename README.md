# SignalRToKusto
An Azure Function C# client that processes, via streaming, messages from a SignalR hub (server) and ingests them in realtime to Kusto (ADX/Fabric KQL Database) using Kusto SDK bindings.

## Usage
For runing the function locally, requires [Azurite](https://marketplace.visualstudio.com/items?itemName=Azurite.azurite) extension in VSCode, open command pallet Azurite: Start

Create a local file local.settings.json
```json
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet",
        "AzureWebJobsSecretStorageType": "files",
        "AzureWebJobsDashboard": "",
        "KustoConnectionString": "Data Source=https://<kustocluster>.<region>.kusto.windows.net;Database=e2e;Fed=True;AppClientId=<AppId>;AppKey=<AppKey>;Authority Id=<Tenant Id>",
        "SignalRConnection": "https://notifications.trimblemaps.com/register?apikey=<APIKey>",
        "MethodName":"notificationMessage",
        "KustoDB": "<DatabaseName>",
        "KustoTable": "<TableName>"
    }
}
```
To run the function locally : ```func start --csharp --port 7104 --verbose```

## Refrences
- [Output binding samples](https://github.com/Azure/Webjobs.Extensions.Kusto/tree/main/samples/samples-csharp/OutputBindingSamples)
- [QueueTrigger sample](https://github.com/Azure/Webjobs.Extensions.Kusto/blob/main/samples/samples-csharp/OutputBindingSamples/QueueImport/QueueTrigger.cs) 
- [Trimble Notifications Service API](https://developer.trimblemaps.com/restful-apis/trip-management/notifications-service/)
- [Console App](https://github.com/hfleitas/app-trimble2kusto/blob/main/notificationsvc/Program.cs)
