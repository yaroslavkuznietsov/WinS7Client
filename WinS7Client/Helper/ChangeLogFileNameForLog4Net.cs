using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinS7Client.Helper
{
    public static class ChangeLogFileNameForLog4Net
    {
        public static bool ChangeLogFileName(string appenderName, string newFilename)
        {
            var rootRepository = log4net.LogManager.GetRepository();
            foreach (var appender in rootRepository.GetAppenders())
            {
                if (appender.Name.Equals(appenderName) && appender is log4net.Appender.FileAppender)
                {
                    var fileAppender = appender as log4net.Appender.FileAppender;
                    fileAppender.File = newFilename;
                    fileAppender.ActivateOptions();
                    return true;  // Appender found and name changed to NewFilename
                }
            }
            return false; // appender not found
        }
    }
}
