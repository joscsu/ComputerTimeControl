using System;
using System.Collections.Generic;
using System.Text;

namespace Worker.Configuration
{
    public class ShutDownInfo
    {
        public string Path { get; set; }
        public string Arguments { get; set; }

        public string WpfClientPath { get; set; }
        public string WpfClientArguments { get; set; }
    }
}
