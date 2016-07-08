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

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public PlayerYear( string first, string last, int year )
        {
            FirstName = first;
            LastName = last;
            Year = year;
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
