using System;
using System.Collections.Generic;
using System.Text;

namespace Worker.Configuration
{

    public class AppSettings
    {
        public Logging Logging { get; set; }
        public Computertimecontrol ComputerTimeControl { get; set; }
        public DatabaseSettings DatabaseSettings { get; set; }
    }

}
