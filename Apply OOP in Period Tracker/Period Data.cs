using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodTracker
{
    internal class PeriodData
    {
        public DateTime lastPeriod { get; }
        public int periodDays { get; }
        public DateTime nextPeriod { get; }
        public DateTime fertileStart { get; }
        public DateTime fertileEnd { get; }

        public PeriodData(DateTime LastPeriod, int PeriodDays)
        {
            lastPeriod = LastPeriod;
            periodDays = PeriodDays;
        }
        public PeriodData(DateTime LastPeriod, int PeriodDays, DateTime NextPeriod, DateTime FertileStart, DateTime FertileEnd)
        {
            lastPeriod = LastPeriod;
            periodDays = PeriodDays;
            nextPeriod = NextPeriod;
            fertileStart = FertileStart;
            fertileEnd = FertileEnd;
        }
    }
}