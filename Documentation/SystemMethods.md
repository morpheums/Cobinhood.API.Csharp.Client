# System Methods
## Get System Time
Get the reference system time as Unix timestamp.
### Example:
 
```c#
    var systemTime = cobinhoodClient.GetSystemTime().Result;
```
### Method Signature:

```c#
    public async Task<SystemTime> GetSystemTime()
```

## Get System Information
Gets system information.
### Example:
 
```c#
    var systemInfo = cobinhoodClient.GetSystemInformation().Result;
```
### Method Signature:

```c#
    public async Task<SystemInformation> GetSystemInformation()
```