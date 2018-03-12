## PowerShell REST API demo

The ambition is to show how a simple REST API can be used from various places. The first example is PowerShell.


### Adding disks (POST)


```powershell
$body = Get-CimInstance win32_logicaldisk | select Name,Description,SystemName,FreeSpace,Size,Compressed,DriveType,FileSystem,MaximumComponentLength,MediaType,SupportsDiskQuotas,SupportsFileBasedCompression,VolumeName,VolumeSerialNumber | ConvertTo-Json

$headers = @{ "Content-Type"="application/json"}
$result = Invoke-RestMethod -Method POST -Uri http://localhost:61170/api/LogicalDisks -Body $body -Headers $headers | ConvertTo-Json

```


### Updating disks (PUT)

```powershell
$body = @"
{
  "id": 2,
  "name": "C:",
  "description": "Local Fixed Disk",
  "systemName": "BFW-5KP0H72",
  "freeSpace": 37952184320,
  "size": 138438242304,
  "compressed": true,
  "driveType": 3,
  "fileSystem": "NTFS",
  "maximumComponentLength": "255",
  "mediaType": 12,
  "supportsDiskQuotas": false,
  "supportsFileBasedCompression": true,
  "volumeDirty": false,
  "volumeName": "Windows",
  "volumeSerialNumber": "F00F7CC4",
  "used": 100486057984
}
"@ 

$headers = @{ "Content-Type"="application/json"}
$result = Invoke-RestMethod -Method PUT -Uri http://localhost:61170/api/LogicalDisks/2 -Body $body -Headers $headers
```

###  Getting datat (Get)

```powershell
$headers = @{ "Content-Type"="application/json"}
$disks = Invoke-RestMethod -Method GET -Uri http://localhost:61170/api/LogicalDisks -Headers $headers -DisableKeepAlive
$disks | Format-Table -AutoSize
```







