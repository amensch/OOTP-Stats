using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTP_Stats
{
    public class PlayerYearList
    {
        private List<PlayerYear> _list;

        public PlayerYearList()
        {
            _list = new List<PlayerYear>();
        }

        public void AddPlayer( PlayerYear p )
        {
            _list.Add(p);
        }

        public IList<PlayerYear> PlayerList
        {
            get { return _list; }
        }

        public List<PlayerYear> PlayerListByYear( int year )
        {
            return (from p in _list where p.Year == year select p).ToList();
        }

        public List<int> ListOfYears()
        {
            return (from p in _list select p.Year).Distinct().ToList();
        }

    }
}
