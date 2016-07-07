using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTP_Stats
{
    public class BattingYear : PlayerYear
    {
        public int AB { get; }
        public int Hits { get; }
        public int HR { get; }
        public int RBI { get; }
        public int K { get; }
        public int BB { get; }
        public int Games { get; }
        public int ExtraBaseHits { get; }
        public int SB { get; }
        public int PA { get; }
        public int TB { get; }

        public enum BattingYearIndex
        {
            Year,
            FirstName,
            LastName,
            AVG,
            OBP,
            SLG,
            AB,
            HR,
            RBI,
            BB,
            K,
            G,
            XBH,
            SB,
            PA,
            H,
            TB
        };

        public BattingYear(string first, string last, int year) : base(first, last, year)
        { }

        public double AVG
        {
            get { return Hits / AB; }
        }

        public double SLG
        {
            get { return TB / AB; }
        }


    }
}
