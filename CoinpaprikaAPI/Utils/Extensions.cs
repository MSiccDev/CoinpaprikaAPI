using CoinpaprikaAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoinpaprikaAPI.Utils
{
    public static class Extensions
    {
        public static string ToArrayString(this string[] array)
        {
            if (array.Length == 1)
                return array[0].ToString();

            if (array.Length > 1)
            {
                var sb = new StringBuilder();

                array.ToList().ForEach(i => sb
                    .Append(i)
                    .Append(","));

                var result = sb.ToString();

                return result.EndsWith(",") ? result.Substring(0, result.Length - 1) : result;
            }

            return string.Empty;
        }

        public static string ToIntervalString(this TickerInterval interval)
        {
            switch (interval)
            {
                case TickerInterval.FiveMinutes:
                    return "5m";
                case TickerInterval.TenMinutes:
                    return "10m";
                case TickerInterval.FifteenMinutes:
                    return "15m";
                case TickerInterval.ThirtyMinutes:
                    return "30m";
                case TickerInterval.FourtyFiveMinutes:
                    return "45m";
                case TickerInterval.OneHour:
                    return "1h";
                case TickerInterval.TwoHours:
                    return "2h";
                case TickerInterval.ThreeHours:
                    return "3h";
                case TickerInterval.SixHours:
                    return "6h";
                case TickerInterval.TwelveHours:
                    return "12h";
                case TickerInterval.TwentyFourHours:
                    return "24h";
                case TickerInterval.OneDay:
                    return "1d";
                case TickerInterval.SevenDays:
                    return "7d";
                case TickerInterval.FourteenDays:
                    return "14d";
                case TickerInterval.ThirtyDays:
                    return "30d";
                case TickerInterval.NinetyDays:
                    return "90d";
                case TickerInterval.ThreeHundredSixtyFiveDays:
                    return "365d";
            }

            return null;
        }

        public static bool IsSupportedQuoteSymbol(this string quoteSymbol)
        {
            if (!string.IsNullOrWhiteSpace(quoteSymbol))
            {
                var allowed = new[] { "BTC", "ETH", "USD", "EUR", "PLN", "KRW", "GBP", "CAD", "JPY", "RUB", "TRY", "NZD", "AUD", "CHF", "UAH", "HKD", "SGD", "NGN", "PHP", "MXN", "BRL", "THB", "CLP", "CNY", "CZK", "DKK", "HUF", "IDR", "ILS", "INR", "MYR", "NOK", "PKR", "SEK", "TWD", "ZAR", "VND", "BOB", "COP", "PEN", "ARS", "ISK" };

                return allowed.Contains(quoteSymbol);
            }
            else
                return false;
        }

        public static bool IsSupportedTagField(this string tagField)
        {
            if (!string.IsNullOrWhiteSpace(tagField))
            {
                var allowed = new[] { "coins", "icos" };

                return allowed.Contains(tagField);
            }
            else
                return false;
        }

        public static string AddParameterToUrl(this string url, string parameterName, object parameterValue)
        {
            if (url.Contains("?"))
            {
                return $"{url}&{parameterName}={parameterValue.ToString()}";
            }
            else
            {
                return $"{url}?{parameterName}={parameterValue.ToString()}";
            }
        }


    }
}
