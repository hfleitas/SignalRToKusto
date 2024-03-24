# 🚦 SignalR to Kusto 🤿
An Azure Function C# client that processes, via streaming, messages from a SignalR hub (server) and ingests them in realtime to Kusto (ADX/Fabric KQL Database) using Kusto SDK bindings.

## Usage 💻
For runing the function locally, requires [Azurite](https://marketplace.visualstudio.com/items?itemName=Azurite.azurite) extension in VSCode, open command pallet Azurite: Start

Create a local file **local.settings.json**
```json
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet",
        "AzureWebJobsSecretStorageType": "files",
        "AzureWebJobsDashboard": "",
        "KustoConnectionString": "Data Source=https://<kustocluster>.<region>.kusto.windows.net;Database=e2e;Fed=True;AppClientId=<AppId>;AppKey=<AppKey>;Authority Id=<Tenant Id>",
        "SignalRConnection": "https://<websocket-category-url>/register?apikey=<APIKey>",
        "MethodName":"notificationMessage",
        "KustoDB": "<DatabaseName>",
        "KustoTable": "<TableName>"
    }
}
```

Install dependencies 💿:

Before you run the function locally, install dependencies exact versions. Use the VSCode NuGet package manager to add them to your project settings. 

VSCode terminal commands:
```
dotnet add package Microsoft.AspNetCore.SignalR.Client --version 6.0.2
dotnet add package Microsoft.Azure.WebJobs.Extensions.Kusto --version 1.0.9-Preview
dotnet add package Microsoft.Azure.WebJobs.Extensions.Storage --version 5.2.2
dotnet add package Microsoft.NET.Sdk.Functions --version 4.3.0
```

To run the function locally 👟: 
```
func start --csharp --port 7104 --verbose
```

To deploy the function 🚀 (can deploy to an existing function & app service plan, or create a new function prior):
```
winget install -e --id Microsoft.AzureCLI
Az Login
Connect-AzAccount -TenantId <your-tenatnt-id>
Set-AzContext -SubscriptionName <your-subcription-name>
func azure functionapp publish <your-az-function-name>
```

## Refrences 📑
- [Output binding samples](https://github.com/Azure/Webjobs.Extensions.Kusto/tree/main/samples/samples-csharp/OutputBindingSamples)
- [QueueTrigger sample](https://github.com/Azure/Webjobs.Extensions.Kusto/blob/main/samples/samples-csharp/OutputBindingSamples/QueueImport/QueueTrigger.cs)
- Timer trigger for Azure Functions - [NCronTab Expressions](https://learn.microsoft.com/azure/azure-functions/functions-bindings-timer?tabs=python-v2%2Cisolated-process%2Cnodejs-v4&pivots=programming-language-csharp#ncrontab-expressions)
- [Trimble Notifications Service API](https://developer.trimblemaps.com/restful-apis/trip-management/notifications-service/)
- [Console App](https://github.com/hfleitas/app-trimble2kusto/blob/main/notificationsvc/Program.cs)
- [Azure Function Core Tools](https://learn.microsoft.com/azure/azure-functions/functions-run-local#install-the-azure-functions-core-tools)
- [FunctionApp Publish](https://learn.microsoft.com/azure/azure-functions/functions-core-tools-reference?tabs=v2#func-azure-functionapp-publish)
