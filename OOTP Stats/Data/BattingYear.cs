using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTP_Stats
{
    public class BattingYear : PlayerYear
    {
        public int AB { get; set; }
        public int Hits { get; set; }
        public int HR { get; set; }
        public int RBI { get; set; }
        public int K { get; set; }
        public int BB { get; set; }
        public int Games { get; set; }
        public int ExtraBaseHits { get; set; }
        public int SB { get; set; }
        public int PA { get; set; }
        public int TB { get; set; }

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
