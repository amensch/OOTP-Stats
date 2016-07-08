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

        public List<BattingYear> GetBattingList(string sortColumnName)
        {
            return _batters = _batters.OrderByDescending(b => b.GetType().GetProperty(sortColumnName).GetValue(b, null)).ToList();
        }

        public List<BattingYear> GetCareerList()
        {
            return _batters.GroupBy(b => new { b.FullName })
                .Select(y => new BattingYear
                {
                    Year = y.Count(),
                    FirstName = y.Min( z => z.FirstName),
                    LastName = y.Min( z => z.LastName),
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
        }

        public List<BattingYear> GetCareerList(string sortColumnName)
        {
            return GetCareerList().OrderByDescending(b => b.GetType().GetProperty(sortColumnName).GetValue(b, null)).ToList();
        }
    }
}
