# Navis.SDK.Bluetracker.Reporting 
This project is a C# wrapper of the Bluetracker-Reporting REST API. It is used to easily query Bluetracker-Reporting entities in C#. 

# Getting Started
`Install-Package Navis.SDK.Bluetracker.Reporting`

or place this directly in your .csproj

`<PackageReference Include="Navis.SDK.Bluetracker.Reporting" Version="2.0.0" />`

Create an **API key**. The key can be created via the **Company Manager** in the **Company Admin** application.

```C#
var apiKey = "myKey";
var http = new HttpClient();

var reportField = new ReportFieldClient(http, apiKey);
var fields = await reportField.GetReportFields();

var reportCLient = new ReportClient(http, apiKey);
var reports = await reportCLient.GetReports(1234567, new DateTime(2021, 1, 1), new DateTime(2021, 12, 31),0, null, null);

var shipClient = new ShipClient(http, apiKey);
var ships = await shipClient.GetShips();

var scheduleClient = new ScheduleClient(http, apiKey);
var schedules = await scheduleClient.GetSchedules(1234567, new DateTime(2021, 1, 1),new DateTime(2021, 12, 31), 0, null, null);
```
