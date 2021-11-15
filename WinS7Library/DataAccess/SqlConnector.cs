using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinS7Library.Helper;
using WinS7Library.Model;

namespace WinS7Library.DataAccess
{
    class SqlConnector : IDataConnection
    {
        private const string db = "Welding";
        public void CreateBurstPressure(Berstdruck model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnHelper.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@Barcode", model.Level2.BauteilDM);
                p.Add("@Pressure", model.Level2.Istberstdruck);

                connection.Execute("dbo.spINSERT_PLC_OUT_BurstingTest", p, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
