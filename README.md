For runing the function locally, create a local file local.settings.json

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