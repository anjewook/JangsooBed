using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.Stats
{
    public class EntrprsStatsSearchT : BaseSearchT
    {
        /// <summary>
        /// 시도구분코드
        /// </summary>
        public string SearchAtptSeCode { get; set; }

        /// <summary>
        /// 계량기종류코드
        /// </summary>
        public string SearchMrnrKndCode { get; set; }
    }
}
