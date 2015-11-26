using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.SystemMng
{
    public class BannerSearchT : BaseSearchT
    {
        /// <summary>
        /// 검색 링크유형코드
        /// </summary>
        public string SearchLinkTyCode { get; set; }

        /// <summary>
        /// 검색 사용여부
        /// </summary>
        public string SearchUseAt { get; set; }
    }
}
