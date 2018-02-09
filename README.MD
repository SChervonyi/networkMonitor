### PosNetworkMonitor

Firstly to build or run application download and install .net core from [here](https://www.microsoft.com/net/download/macos) for your OS. Your can install Runtime to only run application or SDK to build and run.

How to build application:
1. Run command "dotnet restore" to restore all dependencies.
2. Run command "dotnet publish -c Release" to release build application. Or "dotnet publish" for debug build.

How to run application:
1. Run command "dotnet run PosNetworkMonitor.dll". The last parameter is path to PosNetworkMonitor.dll and in project root folder run command would "dotnet run bin/Release/netcoreapp2.0/PosNetworkMonitor.dll"