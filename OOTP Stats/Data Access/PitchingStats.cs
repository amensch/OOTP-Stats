using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTP_Stats
{
    public class PitchingStats
    {
        List<PitchingYear> _pitchers;
        public PitchingStats(IPitchingData data)
        {
            _pitchers = data.LoadPitchers();
        }
    }
}
