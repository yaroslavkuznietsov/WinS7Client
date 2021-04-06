using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinS7Client
{
    public static class DoubleExtensions
    {
        public static double ParseDouble(this string value, double defaultDoubleValue = 0.0)
        {
            double parsedDouble;
            if (double.TryParse(value, out parsedDouble))
            {
                return parsedDouble;
            }

            return defaultDoubleValue;
        }

        public static double? ParseNullableDouble(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            return value.ParseDouble();
        }
    }
}
