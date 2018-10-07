# Coinpaprika API Client
Async C# Client for the [CoinPaprika API](https://api.coinpaprika.com/).

[CoinPaprika](https://coinpaprika.com/) delivers full market data to the world of crypto: coin prices, volumes, market caps, ATHs, return rates and more.

[![Build status](https://ci.appveyor.com/api/projects/status/ot4gk0t8rg1apxac/branch/master?svg=true)](https://ci.appveyor.com/project/MSiccDev/coinpaprikaapi/branch/master) 



### Install
CoinPaprika API Client is [availabe on Nuget](https://www.nuget.org/packages/CoinpaprikaAPI/).

### Dependencies
The library depends on [JSON.net](https://www.nuget.org/packages/Newtonsoft.Json), which is just simply the best Json-library for .NET; It should get installed automatically (with the Nuget package), but depending on your project, you may have to install it manually via Nuget Package Manager/CLI. 

This library is using .NET Standard 2.0, you can check compatibility of your project [here](https://docs.microsoft.com/en-us/dotnet/standard/net-standard#net-implementation-support).


### Getting started
```
CoinpaprikaAPI.Client client = new CoinpaprikaAPI.Client();
```

### Generic return type
All requests return a CoinPaprikaEntity with a generic type (TPaprikaEntity). The CoinPaprikaEntity provides these properties:
+ `Value`, based on the type specified by the API call
+ `Raw` (json value returned by the API)
+ `Error`, may be an HTTP-Error or an API-Error (check the ErrorMessage property for details)
+ `RawError` (json value of the Error property)

If the call was succesfull, `Error` is `null` and `Value` provides the returned data from the API.

### API

##### Get global information
```
var globals = await client.GetClobalsAsync();
```
returns CoinPaprikaEntity of Type [Global](https://github.com/MSiccDev/CoinpaprikaAPI/blob/master/CoinpaprikaAPI/Entity/Global.cs)

##### Get all coins listed on Coinpaprika
```
var coins = await client.GetCoinsAsync();
```
returns CoinPaprikaEntity with a List of objects of Type [CoinInfo](https://github.com/MSiccDev/CoinpaprikaAPI/blob/master/CoinpaprikaAPI/Entity/CoinInfo.cs)

##### Get ticker information for all coins
```
var ticker = await client.GetTickerForAll();
```
returns CoinPaprikaEntity with a List of objects of Type [TickerInfo](https://github.com/MSiccDev/CoinpaprikaAPI/blob/master/CoinpaprikaAPI/Entity/TickerInfo.cs)

##### Get ticker information for specific coin
```
var id = "btc-bitcoin";
var ticker = await client.GetTickerForCoin(id);
```
returns single CoinPaprikaEntity of Type [TickerInfo](https://github.com/MSiccDev/CoinpaprikaAPI/blob/master/CoinpaprikaAPI/Entity/TickerInfo.cs)

##### Search for currencies/icos/people/exchanges/tags
```
var searchterms = "coin";
//passing in null searches all categories
var searchResult = await client.SearchAsync(searchTerms, 10, null);
```
returns CoinPaprikaEntity of Type [SearchResult](https://github.com/MSiccDev/CoinpaprikaAPI/blob/master/CoinpaprikaAPI/Entity/SearchResult.cs)

### License
CoinPaprika C# Client is availabe unter the MIT license, see also the LICENSE file.
