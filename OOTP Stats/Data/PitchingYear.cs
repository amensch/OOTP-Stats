using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTP_Stats
{
    public class PitchingYear : PlayerYear
    {
        public int Games { get; set; }
        public int GS { get; set; }
        public int Wins { get; set; }
        public int Loss { get; set; }
        public int Saves { get; set; }
        public int BB { get; set; }
        public int K { get; set; }
        public int HR { get; set; }
        public int Hits { get; set; }
        public int ER { get; set; }
        public int Outs { get; set; }

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
