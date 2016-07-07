using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTP_Stats
{
    public class PitchingYear : PlayerYear
    {
        public int Games { get; }
        public int GS { get; }
        public int Wins { get; }
        public int Loss { get; }
        public int Saves { get; }
        public int BB { get; }
        public int K { get; }
        public int HR { get; }
        public int Hits { get; }
        public int ER { get; }
        public int Outs { get; }

        public enum PitchingYearIndex
        {
            Year,
            FirstName,
            LastName,
            G,
            GS,
            Win,
            Loss,
            Save,
            ERA,
            IP,
            BB,
            K,
            WHIP,
            HR,
            H,
            ER
        };

        public PitchingYear(string first, string last, int year) : base(first, last, year)
        { }

        public double ERA
        {
            get
            {
                if (Outs == 0)
                    return double.PositiveInfinity;
                else
                    return (ER * 9) / (Outs / 3);
            }
        }

        public double WHIP
        {
            get
            {
                if (Outs == 0)
                    return double.PositiveInfinity;
                else
                    return (BB + Hits) / (Outs / 3);

            }
        }

    }
}
