﻿using System;
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

        public List<BattingYear> GetBattingList(string name)
        {
            return _batters = _batters.OrderByDescending(b => b.GetType().GetProperty(name).GetValue(b, null)).ToList();
        }
    }
}