//edited Apr 2 '13 at 20:54 author: nawfal
//https://stackoverflow.com/questions/4804086/is-there-any-connection-string-parser-in-c
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinS7Client
{
    class ParseStringHelper
    {
        static readonly string[] serverAliases = { "server", "host", "data source", "datasource", "address", "addr", "network address" };
        static readonly string[] databaseAliases = { "database", "initial catalog" };
        static readonly string[] usernameAliases = { "user id", "uid", "username", "user name", "user" };
        static readonly string[] passwordAliases = { "password", "pwd" };

        static readonly string[] rackAliases = { "rack", "rail" };
        static readonly string[] slotAliases = { "slot", "pos" };

        public static string GetPassword(string connectionString)
        {
            return GetValue(connectionString, passwordAliases);
        }

        public static string GetUsername(string connectionString)
        {
            return GetValue(connectionString, usernameAliases);
        }

        public static string GetDatabaseName(string connectionString)
        {
            return GetValue(connectionString, databaseAliases);
        }

        public static string GetServerName(string connectionString)
        {
            return GetValue(connectionString, serverAliases);
        }

        public static string GetRackName(string connectionString)
        {
            return GetValue(connectionString, rackAliases);
        }

        public static string GetSlotName(string connectionString)
        {
            return GetValue(connectionString, slotAliases);
        }

        static string GetValue(string connectionString, params string[] keyAliases)
        {
            var keyValuePairs = connectionString.Split(';')
                                                .Where(kvp => kvp.Contains('='))
                                                .Select(kvp => kvp.Split(new char[] { '=' }, 2))
                                                .ToDictionary(kvp => kvp[0].Trim(),
                                                              kvp => kvp[1].Trim(),
                                                              StringComparer.InvariantCultureIgnoreCase);
            foreach (var alias in keyAliases)
            {
                string value;
                if (keyValuePairs.TryGetValue(alias, out value))
                    return value;
            }
            return string.Empty;
        }
    }
}
