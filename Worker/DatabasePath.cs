using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Worker
{
    public static class DatabasePath
    {
        public static string Get()
        {
            var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
            var pathToContentRoot = Path.GetDirectoryName(pathToExe);
            return Path.Combine(pathToContentRoot, "computertime.db");
        }
    }
}
