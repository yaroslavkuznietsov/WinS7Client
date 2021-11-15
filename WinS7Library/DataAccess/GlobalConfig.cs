using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinS7Library.DataAccess
{
    public static class GlobalConfig
    {
        public static IDataConnection Connection { get; private set; }

        public static void InitializeConnections(DatabaseType db)
        {
            switch (db)
            {
                case DatabaseType.Sql:
                    break;
                case DatabaseType.OtherDb:
                    break;
                default:
                    break;
            }

            if (db == DatabaseType.Sql)
            {
                // Set up SqlConnector properly
                SqlConnector sql = new SqlConnector();
                Connection = sql;
            }
            else if (db == DatabaseType.OtherDb)
            {
                // Create the OtherDb Connection
            }
        }
    }
}
