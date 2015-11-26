using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.SystemMng
{
    public class CmmnCodeSearchT : BaseSearchT
    {
        /// <summary>
        /// 검색 상위기초코드
        /// </summary>
        public string SearchUpperBsisCode { get; set; }

        /// <summary>
        /// 검색 사용여부
        /// </summary>
        public string SearchUseAt { get; set; }
    }
}
