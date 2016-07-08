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
        public List<PitchingYear> GetPitchersList()
        {
            return _pitchers; 
        }

        public List<PitchingYear> GetPitchersList(string name)
        {
            if( name == "ERA" || name == "WHIP")
                return _pitchers = _pitchers.OrderBy(p => p.GetType().GetProperty(name).GetValue(p, null)).ToList();
            else
                return _pitchers = _pitchers.OrderByDescending(p => p.GetType().GetProperty(name).GetValue(p, null)).ToList();
        }
    }
}
