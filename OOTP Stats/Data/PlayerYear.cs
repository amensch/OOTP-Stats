using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTP_Stats
{
    public class PlayerYear : IEquatable<PlayerYear>, IComparable<PlayerYear>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public int Year { get; }

        public PlayerYear( string first, string last, int year )
        {
            FirstName = first;
            LastName = last;
            Year = year;
        }

        public string FullName
        {
            get { return FirstName + " " + LastName;  }
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
