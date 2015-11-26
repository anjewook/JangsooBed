using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.ContentsMng
{
    public class TchnlgyStdrSearchT : BaseSearchT
    {
        /// <summary>
        /// 초기세팅
        /// </summary>
        public TchnlgyStdrSearchT()
        {
            //포털 검색 기본값 : N
            SearchPortalYn = "N";
        }

        /// <summary>
        /// 기술기준일련번호
        /// </summary>
        public long TchnlgyStdrSn { get; set; }

        /// <summary>
        /// 포털 검색 Y/N
        /// </summary>
        public string SearchPortalYn { get; set; }

        /// <summary>
        /// 검색 : 계량기구분코드
        /// </summary>
        public string SearchMrnrSeCode { get; set; }

        /// <summary>  
        /// 검색 : 기술기준명
        /// </summary> 
        public string SearchTchnlgyStdrNm { get; set; }

        /// <summary>  
        /// 검색 : 고시번호명
        /// </summary> 
        public string SearchNtfcNoNm { get; set; }
    }
}
