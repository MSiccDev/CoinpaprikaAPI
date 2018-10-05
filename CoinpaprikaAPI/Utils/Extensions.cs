using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoinpaprikaAPI.Utils
{
    public static class Extensions
    {
        #region global extensions
        public static string AddParametersToUrl(this string url, Dictionary<string, string> parameters)
        {
            var result = url;

            if (parameters.Count > 0)
            {
                foreach (var p in parameters)
                {
                    result = result.AddParameterToUrl(p.Key, p.Value);
                }
            }

            return result;
        }

        public static string AddParameterToUrl(this string url, string parameterName, string parameterValue)
        {
            if (url.Contains("?"))
            {
                return $"{url}&{parameterName}={parameterValue}";
            }
            else
            {
                return $"{url}?{parameterName}={parameterValue}";
            }
        }

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
        #endregion

    }
}
