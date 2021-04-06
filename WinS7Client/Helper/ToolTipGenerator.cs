using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinS7Client
{
    class ToolTipGenerator
    {
        public static void ToolTipShow(object sender, string toolTipText)
        {
            //TextBox TB = (TextBox)sender;
            //int VisibleTime = 1000;  //in milliseconds
            //ToolTip tt = new ToolTip();
            //int xPosToolTip = TB.Size.Width; // + TB.Size.Width;
            //int yPosToolTip = TB.Size.Height;
            //tt.Show(toolTipText, TB, xPosToolTip, yPosToolTip, VisibleTime);
            //return tt;

            ToolTip tt = new ToolTip();
            tt.SetToolTip((Control)sender, toolTipText);
        }
    }
}
