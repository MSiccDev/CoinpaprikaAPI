# Coinpaprika API Client
Async C# Client for the [CoinPaprika API](https://api.coinpaprika.com/). The current version supports CoinPaprika API v1.5.

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
+ `Raw` , json value returned by the API)
+ `Error`, may be an HTTP-Error or an API-Error (check the ErrorMessage property for details)
+ `RawError` , json value of the Error property

If the call was succesfull, `Error` is `null` and `Value` provides the returned data from the API.

### API

##### Get global information
```
var globals = await client.GetClobalsAsync();
```
returns single CoinPaprikaEntity of Type [Global](https://github.com/MSiccDev/CoinpaprikaAPI/blob/master/CoinpaprikaAPI/Entity/Global.cs)

##### Get all coins listed on Coinpaprika
```
var coins = await client.GetCoinsAsync();
```
returns CoinPaprikaEntity with a List of objects of Type [CoinInfo](https://github.com/MSiccDev/CoinpaprikaAPI/blob/master/CoinpaprikaAPI/Entity/CoinInfo.cs)

##### Get coin details by Id
```
var coins = await client.GetCoinByIdAsync("btc-bitcoin");
```
returns single CoinPaprikaEntity of Type [ExtendedCoinInfo](https://github.com/MSiccDev/CoinpaprikaAPI/blob/master/CoinpaprikaAPI/Entity/ExtendedCoinInfo.cs)

##### Get twitter timeline for coin Id
```
var coins = await client.GetTwitterTimelineForCoinAsync("btc-bitcoin");
```
returns CoinPaprikaEntity with a List of objects of Type [CoinTweetInfo](https://github.com/MSiccDev/CoinpaprikaAPI/blob/master/CoinpaprikaAPI/Entity/CoinTweetInfo.cs)

##### Get coin events by coin Id
```
var coins = await client.GetEventsForCoinAsync("btc-bitcoin");
```
returns CoinPaprikaEntity with a List of objects of Type [CoinEventInfo](https://github.com/MSiccDev/CoinpaprikaAPI/blob/master/CoinpaprikaAPI/Entity/CoinEventInfo.cs)

##### Get exchanges by coin Id
```
var coins = await client.GetExchangesForCoinAsync("btc-bitcoin");
```
returns CoinPaprikaEntity with a List of objects of Type [ExchangeInfo](https://github.com/MSiccDev/CoinpaprikaAPI/blob/master/CoinpaprikaAPI/Entity/ExchangeInfo.cs)

##### Get markets by coin Id
```
var coins = await client.GetMarketsForCoinAsync("btc-bitcoin");
```
returns CoinPaprikaEntity with a List of objects of Type [MarketInfo](https://github.com/MSiccDev/CoinpaprikaAPI/blob/master/CoinpaprikaAPI/Entity/MarketInfo.cs)

##### Get latest Open/High/Low/Close values with volume and market_cap by coin Id
```
var coins = await client.GetLatestOhlcForCoinAsync("btc-bitcoin", "USD");
```
returns CoinPaprikaEntity with a List of objects of Type [OhlcValue](https://github.com/MSiccDev/CoinpaprikaAPI/blob/master/CoinpaprikaAPI/Entity/OhlcValue.cs)

##### Get historical Open/High/Low/Close values with volume and market_cap by coin Id
```
var firstOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
var end = DateTime.Now.Subtract(TimeSpan.FromDays(1));

var ohlcvHistorical = await _client.GetHistoricalOhlcForCoinAsync("btc-bitcoin", new DateTimeOffset(firstOfMonth), end, 200, "USD");

```
returns single CoinPaprikaEntity with a List of objects of Type [OhlcValue](https://github.com/MSiccDev/CoinpaprikaAPI/blob/master/CoinpaprikaAPI/Entity/OhlcValue.cs)

##### Get today's Open/High/Low/Close values with volume and market_cap by coin Id
```
var coins = await client.GetTodayOhlcForCoinAsync("btc-bitcoin", "USD");
```
returns CoinPaprikaEntity with a List of objects of Type [OhlcValue](https://github.com/MSiccDev/CoinpaprikaAPI/blob/master/CoinpaprikaAPI/Entity/OhlcValue.cs)

##### Get ticker information for all coins (including quotes)
```
var tickers = await client.GetTickers(new[] { "USD", "CHF", "BTC" });
```
returns CoinPaprikaEntity with a List of objects of Type [TickerWithQuotesInfo](https://github.com/MSiccDev/CoinpaprikaAPI/blob/master/CoinpaprikaAPI/Entity/TickerWithQuotesInfo.cs)

##### Get ticker information for specific coin
```
var ticker = await client.GetTickerForCoin("btc-bitcoin");
```
returns single CoinPaprikaEntity of Type [TickerInfo](https://github.com/MSiccDev/CoinpaprikaAPI/blob/master/CoinpaprikaAPI/Entity/TickerInfo.cs)

##### Get historical ticker information for specific coin
```
var ticker = await _client.GetHistoricalTickerForIdAsync(id, new DateTimeOffset(DateTime.Now.Subtract(TimeSpan.FromDays(1))), DateTimeOffset.Now, 1000, "USD", TickerInterval.OneHour);
```
returns CoinPaprikaEntity with a List of objects of Type [HistoricalTickerInfo](https://github.com/MSiccDev/CoinpaprikaAPI/blob/master/CoinpaprikaAPI/Entity/HistoricalTickerInfo.cs)


##### Get a list of exchanges by quotes
```
var exchanges = await client.GetExchangesAsync(new[] { "USD", "CHF", "BTC" });
```
returns CoinPaprikaEntity with a List of objects of Type [ExtendedExchangeInfo](https://github.com/MSiccDev/CoinpaprikaAPI/blob/master/CoinpaprikaAPI/Entity/ExtendedExchangeInfo.cs)

##### Get exchange by id
```
var ticker = await client.GetExchangeByIdAsync("binance", new[] { "USD", "CHF", "BTC" });
```
returns single CoinPaprikaEntity of Type [ExtendedExchangeInfo](https://github.com/MSiccDev/CoinpaprikaAPI/blob/master/CoinpaprikaAPI/Entity/ExtendedExchangeInfo.cs)

##### Get a list markets of exchange by Id
```
var markets = await client.GetMarketsByExchangeIdAsync("binance");
```
returns CoinPaprikaEntity with a List of objects of Type [ExchangeMarketInfo](https://github.com/MSiccDev/CoinpaprikaAPI/blob/master/CoinpaprikaAPI/Entity/ExchangeMarketInfo.cs)

##### Get people by Id
```
var person = await client.GetPeopleByIdAsync("vitalik-buterin");
```
returns single CoinPaprikaEntity of Type [PersonInfo](https://github.com/MSiccDev/CoinpaprikaAPI/blob/master/CoinpaprikaAPI/Entity/PersonInfo.cs)


##### Get a list of tags
```
var tags = await client.GetTagsAsync(new[] { "coins", "icos" });
```
returns CoinPaprikaEntity with a List of objects of Type [TagInfo](https://github.com/MSiccDev/CoinpaprikaAPI/blob/master/CoinpaprikaAPI/Entity/TagInfo.cs)


##### Get tag info by Id
```
var tag = await client.GetTagByIdAsync("smart-contracts", new[] { "coins", "icos" });
```
returns single CoinPaprikaEntity of Type [TagInfo](https://github.com/MSiccDev/CoinpaprikaAPI/blob/master/CoinpaprikaAPI/Entity/TagInfo.cs)

##### Search for currencies/icos/people/exchanges/tags
```
var searchterms = "coin";
//passing in null searches all categories
var searchResult = await client.SearchAsync(searchTerms, 10, null);
```
returns CoinPaprikaEntity of Type [SearchResult](https://github.com/MSiccDev/CoinpaprikaAPI/blob/master/CoinpaprikaAPI/Entity/SearchResult.cs)

##### Convert currencies
```
var converionResult = await _client.ConvertAsync("btc-bitcoin", "eth-ethereum", 1.5);
```
returns CoinPaprikaEntity of Type [PriceConversionInfo](https://github.com/MSiccDev/CoinpaprikaAPI/blob/master/CoinpaprikaAPI/Entity/PriceConversionInfo.cs)


### License
CoinPaprika C# Client is availabe unter the MIT license, see also the LICENSE file.


