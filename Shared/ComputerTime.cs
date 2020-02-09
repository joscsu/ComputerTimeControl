using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public class ComputerTime
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime? Stop { get; set; }
        public bool Synced { get; set; }

        public override string ToString()
        {
            return $"{Start:HH:mm:ss} - {Stop:HH:mm:ss}";
        }
    }
}
