using CoinpaprikaAPI.JsonConverters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CoinpaprikaAPI.Utils
{
    public class Helpers
    {
        #region Private Fields

        private static JsonSerializer _jsonSerializer = null;

        private static JsonSerializerSettings _jsonSerializerSettings = null;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// gets the current assembly name
        /// </summary>
        public static string GetAssemblyName()
        {
            return typeof(Helpers).Assembly.GetName().Name;
        }

        /// <summary>
        /// gets the current assembly version
        /// </summary>
        public static string GetAssemblyVersion()
        {
            var assembly = typeof(Helpers).Assembly.GetName();
            Version version = assembly.Version;

            return version.ToString();
        }

        /// <summary>
        /// gets a pre-configured JsonSerializer instance
        /// </summary>
        public static JsonSerializer GetConfiguredJsonSerializer()
        {
            if (_jsonSerializer == null)
            {
                _jsonSerializer = JsonSerializer.Create(_jsonSerializerSettings);
            }

            return _jsonSerializer;
        }

        /// <summary>
        /// gets a pre-configured JsonSerializerSettings instance
        /// </summary>
        public static JsonSerializerSettings GetConfiguredJsonSerializerSettings()
        {
            if (_jsonSerializerSettings == null)
            {
                _jsonSerializerSettings = new JsonSerializerSettings()
                {
                    MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                    DateParseHandling = DateParseHandling.None,
                    Converters =
                    {
                        new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
                    },
                    NullValueHandling = NullValueHandling.Ignore
                };
            }
            return _jsonSerializerSettings;
        }

        /// <summary>
        /// gets the logo of the specified coinId
        /// </summary>
        /// <param name="coinId">
        /// the coinId to construct the logo url for
        /// </param>
        /// <returns>
        /// the url of the specified coin logo
        /// </returns>
        public static string GetLogoUrlByCoinId(string coinId)
        {
            return $"https://static2.coinpaprika.com/coin/{coinId}/logo.png";
        }

        #endregion Public Methods
    }
}