using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfClient
{
    public class ComputerTimeViewModel
    {
        private ICollection<ComputerTime> computerTimes;

        public ICollection<ComputerTime> ComputerTimes 
        { 
            get => computerTimes;
            set
            {
                computerTimes = value;
                Sum = CalcSum(value);
            }
        }
        public DateTime Date { get; set; }

        public TimeSpan Sum { get; private set; }

        public static TimeSpan CalcSum(ICollection<ComputerTime> computerTimes)
        {
            TimeSpan sum = new TimeSpan();
            foreach (var item in computerTimes.Where(x => x.Stop.HasValue))
            {
                sum = sum.Add(item.Stop.Value - item.Start);
            }
            return sum;
        }
    }
}
