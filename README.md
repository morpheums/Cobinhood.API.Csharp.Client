<p align="center">
    <a href="https://cobinhood.com" target="_blank"><img width="140"src="https://github.com/morpheums/Cobinhood.API.Csharp.Client/blob/development/Cobinhood.API.Csharp.Client/CobinhoodLogo.png?raw=true">       
    </a>    
    </br> 
    <b style="font-size: 22px;">Cobinhood API Csharp Client</b>
    <br>
    <small style="font-size: 14px;">C#.NET client for Cobinhood Exchange API.</small>
</p>

### C#.NET client for Cobinhood Exchange API.
[![GitHub last commit](https://img.shields.io/github/last-commit/morpheums/Cobinhood.API.Csharp.Client.svg?style=plastic)]()

## Features
- **Very easy** to understand and get started.
- **Complete implementation** of the Cobinhood API and WebSockets.
- API results **deserialized** to concrete objects for ease of usage.
- Includes a **ready to go** test project with **all possible API calls**, just provide your API Key and start testing.

## Installation

**Nuget Package Manager**
```
PM> Install-Package Cobinhood.API.Csharp.Client
```
**.NET CLI**
```
dotnet add package Cobinhood.API.Csharp.Client
```
## Getting Started
In order to use signed methods you need to [create a Cobinhood account](https://cobinhood.com/), if you already have one, go to your account and create a new API private key.

Create an instance of the **ApiClient** which receive the following parameters:

* **ApiKey** - *Key used to authenticate within the API.*
* **ApiUrl (Optional)** - *Base URL of the API.*
* **WebSocketEndpoint (Optional)** - *URL of the WebSockets.* 
```c#
    var apiClient = new ApiClient("@Your-API-Key");
```

Create an instance of the **CobinhoodClient** which will receive the previously created ApiClient
 
```c#
    var cobinhoodClient = new CobinhoodClient(apiClient);
```

## Documentation and Examples
- [System Methods](/Documentation/SystemMethods.md)
- [Market Methods](/Documentation/MarketMethods.md)
- [Chart Methods](/Documentation/ChartMethods.md)
- [Trading Methods](/Documentation/TradingMethods.md)
- [Wallet Methods](/Documentation/WalletMethods.md)
- [WebSocket Methods](/Documentation/WebSocketMethods.md)

## License
Cobinhood.API.Csharp.Client is open-sourced software licensed under the [MIT license](http://opensource.org/licenses/MIT)

## Code of Conduct
Please read and follow our [Code of Conduct](CODE_OF_CONDUCT.md).

## Donations
If you find this tool useful, you can show you support with a kind donation:

**BTC:** 19cgA4YLfxakSvGyu9isdwBJw11mhCVNAp

**ETH:** 0xf059966c50727c1a67c112360686fbfbb0798cfa