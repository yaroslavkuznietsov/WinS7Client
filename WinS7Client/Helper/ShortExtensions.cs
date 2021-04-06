using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinS7Client
{
    public static class ShortExtensions
    {
        public static short ParseShort(this string value, short defaultShortValue = 0)
        {
            short parsedShort;
            if (short.TryParse(value, out parsedShort))
            {
                return parsedShort;
            }

            return defaultShortValue;
        }

        public static short? ParseNullableShort(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            return value.ParseShort();
        }
    }
}
