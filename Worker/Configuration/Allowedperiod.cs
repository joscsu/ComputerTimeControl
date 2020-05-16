using System;

namespace Worker.Configuration
{
    public class Allowedperiod
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public bool TimeIsAllowed(DateTime dt)
        {
            //var start = DateTime.Parse(Start);
            //var end = DateTime.Parse(End);
            return dt >= Start && dt <= End;
        }
    }

}
