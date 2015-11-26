using JS.Boots.Data.SystemMng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.Stats
{
    public class EntrprsStatsPageT
    {
        public EntrprsStatsSearchT SearchModel { get; set; }

        public GridModelT<EntrprsStatsT> GridModel { get; set; }

        public IList<CmmnCodeT> AtptSeCodeList { get; set; }
        
        public IList<CmmnCodeT> MrnrKndCodeList { get; set; }


    }
}
