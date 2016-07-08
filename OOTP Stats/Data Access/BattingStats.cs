using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTP_Stats
{
    public class BattingStats
    {
        List<BattingYear> _batters;

        public BattingStats(IBattingData data)
        {
            _batters = data.LoadBatters();
        }

        public List<BattingYear> GetBattingList()
        {
             return _batters; 
        }

        public List<BattingYear> GetBattingList(string name)
        {
            return _batters = _batters.OrderByDescending(b => b.GetType().GetProperty(name).GetValue(b, null)).ToList();
        }


        // TODO make IQueryable with a new career object
        public IQueryable GetCareerList()
        {
            var list = _batters.GroupBy(b => new { b.FullName })
                .Select(y => new
                {
                    Games = y.Sum(z => z.Games),
                    PA = y.Sum(z => z.PA),
                    AB = y.Sum(z => z.AB),
                    Hits = y.Sum(z => z.Hits),
                    HR = y.Sum(z => z.HR),
                    RBI = y.Sum(z => z.RBI),
                    K = y.Sum(z => z.K),
                    BB = y.Sum(z => z.BB),
                    SB = y.Sum(z => z.SB),
                    XBH = y.Sum(z => z.XBH),
                    TB = y.Sum(z => z.TB)
                }).ToList();
            return list.;
        }
    }
}
