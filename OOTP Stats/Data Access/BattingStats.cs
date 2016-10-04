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

        public List<BattingYear> GetBattingHallList()
        {
            return _batters = _batters.Where(b => b.HallOfFame == true).ToList();
        }

        public List<BattingYear> GetCareerList()
        {
            return _batters.GroupBy(b => new { b.FullName })
                .Select(y => new BattingYear
                {
                    Year = y.Count(),
                    FirstName = y.Min( z => z.FirstName),
                    LastName = y.Min( z => z.LastName),
                    FirstYear = y.Min( z => z.Year),
                    LastYear = y.Max( z => z.Year),
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
                    TB = y.Sum(z => z.TB),
                    HallOfFame = y.All(z => z.HallOfFame)
                }).ToList();
        }

        public List<BattingYear> GetCareerList(string sortColumnName)
        {
            return GetCareerList().OrderByDescending(b => b.GetType().GetProperty(sortColumnName).GetValue(b, null)).ToList();
        }

        public List<BattingYear> GetTeamList()
        {
            return _batters.GroupBy(b => new { b.Year })
                .Select(y => new BattingYear
                {
                    Year = y.Min(z => z.Year),
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

        public List<BattingYear> GetTeamList(string sortColumnName)
        {
            return GetTeamList().OrderByDescending(b => b.GetType().GetProperty(sortColumnName).GetValue(b, null)).ToList();
        }

        public List<BattingYear> YearByYear(string columnName)
        {

            // Get the max value for that stat category for the year.
            var maxValues = from b in _batters
                            group b by b.Year into g
                            select new { Year = g.Key, maxValue = g.Max(p => p.GetType().GetProperty(columnName).GetValue(p, null)) };

            // Build a list of matches
            var results = new List<BattingYear>();

            foreach( var maxValue in maxValues )
            {
                var matches = from b in _batters
                              where (b.Year == maxValue.Year) && 
                                    //((b.GetType().GetProperty(columnName).GetValue(b, null)) == maxValue.maxValue)
                                    (b.PA == (int)maxValue.maxValue)
                                select b;
                results.AddRange(matches);
            }

            return results.OrderByDescending(b => b.Year).ToList();
                    
                    

            //BattingYear batter = new BattingYear();

            //if (batter.GetType().GetProperty(columnName).PropertyType == typeof(int))
            //{

            //}
            //else if (batter.GetType().GetProperty(columnName).PropertyType == typeof(double))
            //{

            //}
            //else if (batter.GetType().GetProperty(columnName).PropertyType == typeof(string))
            //{


            //return _batters.GroupBy(b => new { b.Year })
            //               .Select(y => new YearByYearQuery
            //               {
            //                   Year = y.Min( z => z.Year),
            //                   Name = y.Min( z => z.FullName ),
            //                   Result = (double)y.Max( p => p.GetType().GetProperty(columnName).GetValue(p, null) )
            //               }).ToList();


            //var results = from b in _batters join m in maxValues on new { b.Year, b.PA } equals new { m.Year, (int)m.maxValue }
            //              select new {}




        }
    }
}
