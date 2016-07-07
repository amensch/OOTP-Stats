using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTP_Stats
{
    public class Stats
    {
        public BattingStats Batters { get; set; }
        public PitchingStats Pitchers { get; set; }

        public Stats(IDataStore data)
        {
            Batters = new BattingStats(data);
            Pitchers = new PitchingStats(data);
        }
    }
}
