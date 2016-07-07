using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTP_Stats
{
    public interface IPitchingData
    {
        List<PitchingYear> LoadPitchers();
    }
}
