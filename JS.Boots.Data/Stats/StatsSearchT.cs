using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.Stats
{
    /// <summary>
    /// 통계 검색 Model
    /// </summary>
    public class StatsSearchT : BaseSearchT
    {
        /// <summary>
        /// 검색 : 계량기종류
        /// </summary>
        public string SearchMrnrSeCode { get; set; }

        /// <summary>
        /// 검색 : 합격/불합격 Y/N
        /// </summary>
        public string SearchPsexamAt { get; set; }
    }
}
