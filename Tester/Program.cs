using CoinpaprikaAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tester
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //await TestGlobalsAsync();
            //await TestCoinsAsync();
            //await TestCoinByIdAsync();
            //await TestTickerAllAsync();
            //await TestHistoricalTickerAsync();
            //await TestTickerAsync();
            //await TestSearchAsync();
            //await TestPeopleInfoAsync();
            //await TestTagsAsync();
            //await TestExchangesAsync();
            //await TestConversionAsync();

            await TestContractsAsync();
        }



        private static CoinpaprikaAPI.Client _client = new CoinpaprikaAPI.Client();

        static async Task TestGlobalsAsync()
        {
            Console.WriteLine("fetching globals...");

            var globals = await _client.GetClobalsAsync();

            if (globals.Error == null)
            {
                Console.WriteLine($"{nameof(globals.Value.MarketCapUsd)}: {globals.Value.MarketCapUsd}");
                Console.WriteLine($"{nameof(globals.Value.Volume24HUsd)}: {globals.Value.Volume24HUsd}");
                Console.WriteLine($"{nameof(globals.Value.BitcoinDominancePercentage)}: {globals.Value.BitcoinDominancePercentage}");
                Console.WriteLine($"{nameof(globals.Value.CryptocurrenciesNumber)}: {globals.Value.CryptocurrenciesNumber}");
                Console.WriteLine($"{nameof(globals.Value.LastUpdated)}: {globals.Value.LastUpdated}");
                Console.WriteLine("Press any key to finish test...");
                Console.ReadLine();
                Console.WriteLine("Bye!");
            }
        }

        static async Task TestCoinsAsync()
        {
            Console.WriteLine("fetching available coins...");

            var coins = await _client.GetCoinsAsync();

            if (coins.Error == null)
            {
                Console.WriteLine("coins available on CoinPaprika: ");
                foreach (var c in coins.Value.OrderBy(c => c.Rank))
                {
                    Console.WriteLine($"{c.Name}({c.Id}({c.Symbol})) - {c.Rank} - {nameof(c.IsActive)}:{c.IsActive}/{nameof(c.IsNew)}:{c.IsNew}");
                }

                Console.WriteLine("Press any key to finish test...");
                Console.ReadLine();
                Console.WriteLine("Bye!");
            }
        }

        static async Task TestCoinByIdAsync()
        {
            Console.WriteLine("Testing Coin by Id:");

            Console.WriteLine("enter coin id:");

            var id = Console.ReadLine();

            Console.WriteLine($"fetching extended CoinInfo for id '{id}' ...");

            var extCoinInfo = await _client.GetCoinByIdAsync(id);

            if (extCoinInfo.Error == null)
            {
                Console.WriteLine($"Extended CoinInfo for {extCoinInfo.Value.Name}:");
                Console.WriteLine($"{extCoinInfo.Value.Description}");
                Console.WriteLine($"WhitePaper-Link: {extCoinInfo.Value.Whitepaper.Link}");
                Console.WriteLine("Explorers:");
                extCoinInfo.Value.Links.Explorer.ForEach(e => Console.WriteLine(e.OriginalString));
                Console.WriteLine("Website/Source Links:");
                extCoinInfo.Value.Links.Website?.ForEach(e => Console.WriteLine(e.OriginalString));
                extCoinInfo.Value.Links.SourceCode?.ForEach(e => Console.WriteLine(e.OriginalString));
                Console.WriteLine("Social Media Links:");
                extCoinInfo.Value.Links.Facebook?.ForEach(e => Console.WriteLine(e?.OriginalString));
                extCoinInfo.Value.Links.Medium?.ForEach(e => Console.WriteLine(e?.OriginalString));
                extCoinInfo.Value.Links.Reddit?.ForEach(e => Console.WriteLine(e?.OriginalString));
                extCoinInfo.Value.Links.Youtube?.ForEach(e => Console.WriteLine(e?.OriginalString));
            }
            else
            {
               Console.WriteLine($"{id} not found, please enter a valid id next time");
            }

            Console.WriteLine("Tweets:");
            var timeline = await _client.GetTwitterTimelineForCoinAsync(id);
            timeline.Value.ForEach(t => Console.WriteLine($"{t.Date}: {t.Status})"));

            Console.WriteLine("Events:");
            var events = await _client.GetEventsForCoinAsync(id);
            events.Value.ForEach(e => Console.WriteLine($"{e.Date} - {e.DateTo} : {e.Name}"));

            Console.WriteLine("Exchanges:");
            var exchanges = await _client.GetExchangesForCoinAsync(id);
            exchanges.Value.ForEach(e => Console.WriteLine($"{e.Name} - {e.AdjustedVolume24HShare}%"));

            Console.WriteLine("Markets:");
            var markets = await _client.GetMarketsForCoinAsync(id, new[] {"USD", "BTC" });
            markets.Value.ForEach(m => Console.WriteLine($"{m.BaseCurrencyName} on {m.ExchangeName}"));

            Console.WriteLine("OHLC Latest:");
            var ohlcvLatest = await _client.GetLatestOhlcForCoinAsync(id);
            ohlcvLatest.Value.ForEach(v => Console.WriteLine($"{id}: Open: {v.Open}({v.TimeOpen}), Close: {v.Close}({v.TimeClose}), High: {v.High}, Low: {v.Low}"));


            Console.WriteLine("OHLC Historical:");

            var firstOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var end = DateTime.Now.Subtract(TimeSpan.FromDays(1));

            var ohlcvHistorical = await _client.GetHistoricalOhlcForCoinAsync(id, new DateTimeOffset(firstOfMonth), end, 200);
            ohlcvHistorical.Value.ForEach(v => Console.WriteLine($"{id}: Open: {v.Open}({v.TimeOpen}), Close: {v.Close}({v.TimeClose}), High: {v.High}, Low: {v.Low}"));

            Console.ReadLine();
            Console.WriteLine("Bye!");
        }

        static async Task TestTickerAllAsync()
        {
            Console.WriteLine("fetching ticker...");

            var ticker = await _client.GetTickersAsync(new[] { "USD", "BTC" });

            if (ticker.Error == null)
            {
                Console.WriteLine("CoinPaprika Tickers: ");
                foreach (var t in ticker.Value.OrderBy(c => c.Rank))
                {
                    Console.WriteLine($"{t.Name}({t.Id}({t.Symbol})) - {t.Rank} - BTC:{t.Quotes["BTC"].Price}/USD:{t.Quotes["USD"].Price} - PercentChange24h:{t.Quotes["BTC"].PercentChange24H}%(BTC)/{t.Quotes["USD"].PercentChange24H}%(USD)");
                }

                Console.WriteLine("Press any key to finish test...");
                Console.ReadLine();
                Console.WriteLine("Bye!");
            }
        }

        static async Task TestTickerAsync()
        {
            Console.WriteLine("Testing coin Ticker info:");

            Console.WriteLine("enter coin id:");

            var id = Console.ReadLine();

            Console.WriteLine($"fetching ticker for id {id} ...");

            var ticker = await _client.GetTickerForIdAsync(id);

            if (ticker.Error == null)
            {
                Console.WriteLine($"{ticker.Value.Name}({ticker.Value.Id}({ticker.Value.Symbol})) - {ticker.Value.Rank} - BTC:{ticker.Value.PriceBtc}/USD:{ticker.Value.PriceUsd} - PercentChange24h:{ticker.Value.PercentChange24H}");
                Console.WriteLine("Press any key to finish test...");
            }
            else
            {
                Console.WriteLine($"CoinPaprika returned an error: {ticker.Error.ErrorMessage}");
            }

            Console.ReadLine();
            Console.WriteLine("Bye!");
        }


        static async Task TestHistoricalTickerAsync()
        {
            Console.WriteLine("Testing historical Ticker info:");

            Console.WriteLine("enter coin id:");

            var id = Console.ReadLine();

            Console.WriteLine($"fetching ticker for id {id} ...");

            var ticker = await _client.GetHistoricalTickerForIdAsync(id, new DateTimeOffset(DateTime.Now.Subtract(TimeSpan.FromDays(1))), DateTimeOffset.Now, 1000, "USD", TickerInterval.OneHour);

            if (ticker.Error == null)
            {
                foreach (var historic in ticker.Value)
                {
                    Console.WriteLine($"(Ticker ({id}) : {historic.Timestamp}: ({historic.Price})) - {historic.Volume24H}");

                }
                Console.WriteLine("Press any key to finish test...");
            }
            else
            {
                Console.WriteLine($"CoinPaprika returned an error: {ticker.Error.ErrorMessage}");
            }

            Console.ReadLine();
            Console.WriteLine("Bye!");
        }

        static async Task TestPeopleInfoAsync()
        {
            Console.WriteLine("Testing Personinfo:");

            Console.WriteLine("enter person-id:");

            var id = Console.ReadLine();

            Console.WriteLine($"fetching person with id {id} ...");

            var person = await _client.GetPeopleByIdAsync(id);

            if (person.Error == null)
            {
                Console.WriteLine($"Found: {person.Value.Name}:");
                Console.WriteLine($"{person.Value.Description}");
            }
            else
            {
                Console.WriteLine($"no person with id {id} found");
            }

            Console.ReadLine();
            Console.WriteLine("Bye!");
        }

        static async Task TestSearchAsync()
        {
            Console.WriteLine("Testing search:");

            Console.WriteLine("enter search terms:");

            var searchTerms = Console.ReadLine();

            Console.WriteLine("choose from categories (enter the number, select multiple with comma seperation):");
            Console.WriteLine("0: All");
            Console.WriteLine("1: currencies");
            Console.WriteLine("2: exchanges");
            Console.WriteLine("3: icos");
            Console.WriteLine("4: people");
            Console.WriteLine("5: tags");

            var categories = Console.ReadLine();

            List<SearchCategory> searchCategories = null;
            if (!categories.Contains("0") && !(categories.Contains("All")))
            {
                searchCategories = new List<SearchCategory>();

                if (categories.Contains("1") || categories.Contains("currencies"))
                    searchCategories.Add(SearchCategory.Currencies);
                if (categories.Contains("2") || categories.Contains("exchanges"))
                    searchCategories.Add(SearchCategory.Exchanges);
                if (categories.Contains("3") || categories.Contains("icos"))
                    searchCategories.Add(SearchCategory.Icos);
                if (categories.Contains("4") || categories.Contains("people"))
                    searchCategories.Add(SearchCategory.People);
                if (categories.Contains("5") || categories.Contains("tags"))
                    searchCategories.Add(SearchCategory.Tags);
            }

            var result = await _client.SearchAsync(searchTerms, 10, searchCategories);

            if (result.Error == null)
            {
                Console.WriteLine("search returned following json string as result:");
                Console.WriteLine(result.Raw);

                Console.WriteLine("Press any key to finish search test...");
            }
            else
            {
                Console.WriteLine($"CoinPaprika returned an error: {result.Error.ErrorMessage}");
            }

            Console.ReadLine();
            Console.WriteLine("Bye!");
        }

        static async Task TestTagsAsync()
        {
            Console.WriteLine("Testing Tags:");

            Console.WriteLine("Fetching available tags:");
            var listTags = await _client.GetTagsAsync();

            Console.WriteLine($"received a total number of {listTags.Value.Count} TagInfos.");

            Console.ReadLine();

            Console.WriteLine("selecting a random tag from reveived tags list ...");

            var rnd = new Random();
            var selected = rnd.Next(listTags.Value.Count - 1);

            var tagId = listTags.Value.ElementAt(selected).Id;

            Console.WriteLine($"Fetching info for tag: {tagId}");

            var tagById = await _client.GetTagByIdAsync(tagId);

            Console.WriteLine($"TagInfo: {tagById.Value.Name} ({tagById.Value.Type}) - {tagById.Value.Description}");

            Console.ReadLine();
            Console.WriteLine("Bye!");
        }

        static async Task TestExchangesAsync()
        {
            Console.WriteLine("Testing Echanges:");

            Console.WriteLine("Fetching available exchanges:");
            var listExchanges = await _client.GetExchangesAsync(new[] {"USD", "BTC", "ETH" });

            Console.WriteLine($"received a total number of {listExchanges.Value.Count} Exchanges.");

            Console.ReadLine();

            Console.WriteLine("selecting a random exchange from reveived list ...");

            var rnd = new Random();
            var selected = rnd.Next(listExchanges.Value.Count - 1);

            var exchangeId = listExchanges.Value.ElementAt(selected).Id;

            Console.WriteLine($"Getting Exchange info for id {exchangeId}...");

            var exchangeById = await _client.GetExchangeByIdAsync(exchangeId, new[] { "USD", "BTC", "ETH" });

            if (exchangeById.Error == null)
            {
                Console.WriteLine($"{exchangeById.Value.Name}, Rank: {exchangeById.Value.AdjustedRank}, Web: {exchangeById.Value.Links.Website.FirstOrDefault()} ");
            }

            Console.WriteLine($"Getting Market info for id {exchangeId} ...");

            var markets = await _client.GetMarketsByExchangeIdAsync(exchangeId);

            if (markets.Error == null)
            {
                markets.Value.ForEach(m => Console.WriteLine($"Market: {m.Pair} - {m.Category}, Volume24H%:{m.ReportedVolume24HShare}"));
            }


            Console.ReadLine();
            Console.WriteLine("Bye!");
        }

        static async Task TestConversionAsync()
        {
            Console.WriteLine("Testing conversion:");

            Console.WriteLine("enter base currency:");
            var baseCcyId = Console.ReadLine();

            Console.WriteLine("enter target currency:");
            var targetCcyId = Console.ReadLine();

            Console.WriteLine("enter amount:");
            var amount = Console.ReadLine();

            if (decimal.TryParse(amount, out var final))
            {
                var result = await _client.ConvertAsync(baseCcyId, targetCcyId, final);

                if (result.Error == null)
                {
                    Console.WriteLine($"Conversion Result: {final} {result.Value.BaseCurrencyName} are worth {result.Value.Price} {result.Value.QuoteCurrencyName}");
                    Console.WriteLine("Press any key to finish search test...");
                }
                else
                {
                    Console.WriteLine($"CoinPaprika returned an error: {result.Error.ErrorMessage}");
                }
            }

            Console.ReadLine();
            Console.WriteLine("Bye!");
        }


        static async Task TestContractsAsync()
        {
            Console.WriteLine("Testing Contracts...");

            var platforms = await _client.GetContractPlatformsAsync();

            if (platforms.Error == null)
            {
                Console.WriteLine($"Received {platforms.Value.Count} results:");
                foreach (var platform in platforms.Value)
                    Console.WriteLine(platform);

                Console.WriteLine("Fetching contract addresses of Neo ....");

                var addresses = await _client.GetContractAddressesForPlatform("neo-neo");

                if (addresses.Error == null)
                {
                    Console.WriteLine($"Found {addresses.Value.Count} contract adresses:");

                    foreach (var address in addresses.Value)
                        Console.WriteLine($"{address.Id} - {address.Address}");
                }

            }


            Console.ReadLine();
            Console.WriteLine("Bye!");
        }
    }
}
