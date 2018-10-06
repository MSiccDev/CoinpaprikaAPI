# Coinpaprika API Client
Async C# Client for the CoinPaprika API

[![Build status](https://ci.appveyor.com/api/projects/status/ot4gk0t8rg1apxac/branch/master?svg=true)](https://ci.appveyor.com/project/MSiccDev/coinpaprikaapi/branch/master) 


### Install

**Nuget package cooming soon**

For the moment, clone this repository and add it to you project.

### Dependencies
The library depends on [JSON.net](https://www.nuget.org/packages/Newtonsoft.Json), which is easily the best Json-library for .NET; It should get installed automatically (with the Nuget package), but depending on your project, you may have to install it manually via Nuget Package Manager. 

Please note that this library is written with .NET Standard 2.0, you can check compatibility of your project [here](https://docs.microsoft.com/en-us/dotnet/standard/net-standard#net-implementation-support).


### Getting started
```
CoinpaprikaAPI.Client client = new CoinpaprikaAPI.Client();
```

### Generic return type
All requests return a CoinPaprikaEntity with a generic defined type (TPaprikaEntity). The CoinPaprikaEntity provides:
+ `Value`, based on the type specified by the API call
+ `RawValue` (the json value returned by the API)
+ `Error`, may be an HTTP-Error or an API-Error (check the ErrorMessage property for details)
+ `RawError` (the json value of the Error property)

If the call was succesfull, `Error` is `null` and `Value` provides the returned data from the API.

### API

##### Get global information
```
var globals = await client.GetClobalsAsync();
```
returns CoinPaprikaEntity [Global](https://github.com/MSiccDev/CoinpaprikaAPI/blob/master/CoinpaprikaAPI/Entity/Global.cs)

##### Get all coins listed on Coinpaprika
```
var coins = await client.GetCoinsAsync();
```
returns CoinPaprikaEntity with a List of [CoinInfo](https://github.com/MSiccDev/CoinpaprikaAPI/blob/master/CoinpaprikaAPI/Entity/CoinInfo.cs)

##### Get ticker information for all coins
```
var ticker = await client.GetTickerForAll();
```
returns CoinPaprikaEntity with a List of [TickerInfo](https://github.com/MSiccDev/CoinpaprikaAPI/blob/master/CoinpaprikaAPI/Entity/TickerInfo.cs)

##### Get ticker information for specific coin
```
var id = "btc-bitcoin";
var ticker = await client.GetTickerForCoin(id);
```
returns CoinPaprikaEntity with a single [TickerInfo](https://github.com/MSiccDev/CoinpaprikaAPI/blob/master/CoinpaprikaAPI/Entity/TickerInfo.cs)

##### Search for currencies/icos/people/exchanges/tags
```
var searchterms = "coin";
//passing in null searches all categories
var searchResult = await client.SearchAsync(searchTerms, 10, null);
```
returns CoinPaprikaEntity with [SearchResult](https://github.com/MSiccDev/CoinpaprikaAPI/blob/master/CoinpaprikaAPI/Entity/SearchResult.cs)

### License
CoinPaprika C# Client is availabe unter the MIT license, see also the LICENSE file.
