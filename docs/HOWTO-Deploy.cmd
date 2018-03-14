# HOWTO: Build & Deploy

We deploy this app using Octopus Deploy. In order to do that the application must be built and then
packaged into a NuGet or Zip file. Here you can find out how to do that.

## Build & packaged

Change location to the projects home folder. Then build the project for release:

```powershell
dotnet publish Basefarm.Demo.Web --output .\published --configuration Release
```
Once the project have been built ok it's time to pack it up for deployment via Octopus:

```powershell
octo pack --id Basefarm.Demo.Web --basePath .\Basefarm.Demo.Web\published --format=zip --outFolder=.\packaged
```


## Setting up IIS

https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/iis/?tabs=aspnetcore2x