using CoinpaprikaAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
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
            //await TestTickerAllAsync();
            //await TestTickerAsync();
            await TestSearchAsync();
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

        static async Task TestTickerAllAsync()
        {
            Console.WriteLine("fetching ticker...");

            var ticker = await _client.GetTickerForAll();

            if (ticker.Error == null)
            {
                Console.WriteLine("CoinPaprika Ticker (all): ");
                foreach (var t in ticker.Value.OrderBy(c => c.Rank))
                {
                    Console.WriteLine($"{t.Name}({t.Id}({t.Symbol})) - {t.Rank} - {nameof(t.PriceBtc)}:{t.PriceBtc}/{nameof(t.PriceUsd)}:{t.PriceUsd} - {nameof(t.PercentChange24h)}:{t.PercentChange24h}");
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

            var ticker = await _client.GetTickerForCoin(id);

            if (ticker.Error == null)
            {

                Console.WriteLine($"{ticker.Value.Name}({ticker.Value.Id}({ticker.Value.Symbol})) - {ticker.Value.Rank} - {nameof(ticker.Value.PriceBtc)}:{ticker.Value.PriceBtc}/{nameof(ticker.Value.PriceUsd)}:{ticker.Value.PriceUsd} - {nameof(ticker.Value.PercentChange24h)}:{ticker.Value.PercentChange24h}");
                Console.WriteLine("Press any key to finish test...");
            }
            else
            {
                Console.WriteLine($"CoinPaprika returned an error: {ticker.Error.ErrorMessage}");
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

    }
}
