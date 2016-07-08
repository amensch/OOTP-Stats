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

        public List<PitchingYear> GetCareerList()
        {
            return _pitchers.GroupBy(b => new { b.FullName })
                .Select(y => new PitchingYear
                {
                    Year = y.Count(),
                    FirstName = y.Min(z => z.FirstName),
                    LastName = y.Min(z => z.LastName),
                    FirstYear = y.Min(z => z.Year),
                    LastYear = y.Max(z => z.Year),
                    Games = y.Sum(z => z.Games),
                    GS = y.Sum(z => z.GS),
                    Wins = y.Sum(z => z.Wins),
                    Loss = y.Sum(z => z.Loss),
                    Saves = y.Sum(z => z.Saves),
                    BB = y.Sum(z => z.BB),
                    K = y.Sum(z => z.K),
                    HR = y.Sum(z => z.HR),
                    Hits = y.Sum(z => z.Hits),
                    ER = y.Sum(z => z.ER),
                    Outs = y.Sum(z => z.Outs)
                }).ToList();
        }

        public List<PitchingYear> GetCareerList(string name)
        {
            if (name == "ERA" || name == "WHIP")
                return GetCareerList().OrderBy(p => p.GetType().GetProperty(name).GetValue(p, null)).ToList();
            else
                return GetCareerList().OrderByDescending(p => p.GetType().GetProperty(name).GetValue(p, null)).ToList();
        }

        public List<PitchingYear> GetTeamList()
        {
            return _pitchers.GroupBy(b => new { b.Year })
                .Select(y => new PitchingYear
                {
                    Year = y.Min(z => z.Year),
                    Games = y.Sum(z => z.Games),
                    GS = y.Sum(z => z.GS),
                    Wins = y.Sum(z => z.Wins),
                    Loss = y.Sum(z => z.Loss),
                    Saves = y.Sum(z => z.Saves),
                    BB = y.Sum(z => z.BB),
                    K = y.Sum(z => z.K),
                    HR = y.Sum(z => z.HR),
                    Hits = y.Sum(z => z.Hits),
                    ER = y.Sum(z => z.ER),
                    Outs = y.Sum(z => z.Outs)
                }).ToList();
        }

        public List<PitchingYear> GetTeamList(string name)
        {
            if (name == "ERA" || name == "WHIP")
                return GetTeamList().OrderBy(p => p.GetType().GetProperty(name).GetValue(p, null)).ToList();
            else
                return GetTeamList().OrderByDescending(p => p.GetType().GetProperty(name).GetValue(p, null)).ToList();
        }

        public void YearByYear(string columnName)
        {
            var maxValues = from p in _pitchers
                            group p by p.Year into grp
                            select new
                            {
                                Year = grp.Select(g => g.Year),
                                Name = grp.Select(g => g.FullName),
                                Result = grp.Max(p => p.GetType().GetProperty(columnName).GetValue(p, null))
                            };

            var result = maxValues;
        }
    }
}
