using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTP_Stats
{
    public class PlayerYear : IEquatable<PlayerYear>, IComparable<PlayerYear>
    {
        public int Year { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FirstYear { get; set; }
        public int LastYear { get; set; }
        public bool HallOfFame { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public string Years
        {
            get { return FirstYear.ToString() + "-" + LastYear.ToString(); }
        }

        public PlayerYear( string first, string last, int year, bool hall )
        {
            FirstName = first;
            LastName = last;
            Year = year;
            HallOfFame = hall;
        }

        public int CompareTo(PlayerYear other)
        {
            int value = LastName.CompareTo(other.LastName);
            if (value == 0)
                value = FirstName.CompareTo(other.FirstName);
            if (value == 0)
                value = Year.CompareTo(other.Year);
            return value;
        }

        public bool Equals(PlayerYear other)
        {
            return (FirstName == other.FirstName && LastName == other.LastName);
        }
    }
}
