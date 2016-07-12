using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public PitchingYear() : base ("","",0,false)
        { }

        public PitchingYear(string first, string last, int year, bool hall) : base(first, last, year, hall)
        { }

        public double IP
        {
            get
            {
                double ip = Outs / 3;
                int frac = Outs % 3;
                if (frac == 1)
                    ip += .1;
                else if (frac == 2)
                    ip += .2;

                return ip;
            }
        }

        public double ERA
        {
            get
            {
                if (Outs == 0)
                    return double.PositiveInfinity;
                else
                    return ((double)ER * 9) / ((double)Outs / 3);
            }
        }

        public double WHIP
        {
            get
            {
                if (Outs == 0)
                    return double.PositiveInfinity;
                else
                    return (BB + Hits) / ((double)Outs / 3);

            }
        }

        public double Kper9
        {
            get
            {
                if (Outs == 0)
                    return 0;
                else
                    return ((double)K * 9) / ((double)Outs / 3);
            }
        }

        public double BBper9
        {
            get
            {
                if (Outs == 0)
                    return 0;
                else
                    return ((double)BB * 9) / ((double)Outs / 3);
            }
        }
    }
}
