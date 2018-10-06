using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;

namespace CoinpaprikaAPI.Utils
{
    public class Helpers
    {
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

        private static JsonSerializer _jsonSerializer = null;
        private static JsonSerializerSettings _jsonSerializerSettings = null;

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
                    }
                };
            }
            return _jsonSerializerSettings;
        }

    }

}
