# SignalRToKusto
An Azure Function C# client that processes, via streaming, messages from a SignalR hub (server) and ingest them in realtime to Kusto (ADX/Fabric KQL Database) using Kusto SDK bindings.

## Refrences
- [Output binding samples](https://github.com/Azure/Webjobs.Extensions.Kusto/tree/main/samples/samples-csharp/OutputBindingSamples)
- [QueueTrigger sample](https://github.com/Azure/Webjobs.Extensions.Kusto/blob/main/samples/samples-csharp/OutputBindingSamples/QueueImport/QueueTrigger.cs) 
- [Trimble Notifications Service API](https://developer.trimblemaps.com/restful-apis/trip-management/notifications-service/)
- [Console App](https://github.com/hfleitas/app-trimble2kusto/blob/main/notificationsvc/Program.cs)
