using System;

namespace ComputerTime.Shared
{
    public class PlayException
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public int Duration { get; set; }
        public string Reason { get; set; }
    }
}
