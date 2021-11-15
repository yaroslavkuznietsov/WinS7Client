using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinS7Library.Model;

namespace WinS7Library.DataAccess
{
    public interface IDataConnection
    {
        void CreateBurstPressure(Berstdruck berstdruck);
    }
}
