using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.UserMng
{
    public class AppnReqstRealmT : BaseModelT
    {
        /// <summary>  
        /// 기관일련번호
        /// </summary> 
        public long InsttSn { get; set; }

        /// <summary>  
        /// 지정신청분야일련번호
        /// </summary> 
        public long AppnReqstRealmSn { get; set; }

        /// <summary>
        /// 형식승인검정구분코드
        /// </summary>
        public string FomConfmAthrzSeCode { get; set; }

        /// <summary>  
        /// 계량기구분코드
        /// </summary> 
        public string MrnrSeCode { get; set; }

        /// <summary>  
        /// 지정신청분야내용
        /// </summary> 
        public string AppnReqstRealmCn { get; set; }

    }
}
