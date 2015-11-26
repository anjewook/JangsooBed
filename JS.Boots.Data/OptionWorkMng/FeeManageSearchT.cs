using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.OptionWorkMng
{
    public class FeeManageSearchT : BaseSearchT
    {
        /// <summary>  
        /// 수수료구분코드
        /// </summary> 
        public string ParamFeeSeCode { get; set; }

        /// <summary>  
        /// 수수료일련번호
        /// </summary> 
        public long ParamFeeSn { get; set; }

        /// <summary>  
        /// 검색 : 수수료구분코드
        /// </summary> 
        public string SearchFeeSeCode { get; set; }

        /// <summary>  
        /// 검색 : 수수료명
        /// </summary> 
        public string SearchFeeNm { get; set; }

        /// <summary>  
        /// 검색 : 규격명
        /// </summary> 
        public string SearchStndrdNm { get; set; }  
    }
}
