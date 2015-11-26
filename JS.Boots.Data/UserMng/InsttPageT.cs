using JS.Boots.Data.SystemMng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.UserMng
{
    public class InsttPageT
    {
        public InsttSearchT SearchModel { get; set; }
        public GridModelT<InsttT> GridModel { get; set; }
        public InsttT InsttT { get; set; }
        public IList<CmmnCodeT> AdresSeCodeList { get; set; }
        public IList<CmmnCodeT> InsttSttusCodeList { get; set; }
        public IList<CmmnCodeT> TelnoList { get; set; }
        public IList<CmmnCodeT> MrnrSeCodeList { get; set; }
        public IList<CmmnCodeT> InsttSeCodeList { get; set; }
        public IList<CmmnCodeT> AtptSeCodeList { get; set; }
        public IList<CmmnCodeT> GuGunSeCodeList { get; set; }

        /// <summary>
        /// 지정신청분야 목록
        /// </summary>
        public IList<AppnReqstRealmT> AppnReqstRealmList { get; set; }
    
        /// <summary>
        /// 검정 지정신청분야 목록
        /// </summary>
        public IList<AppnReqstRealmT> AthrzAppnReqstRealmList { get; set; }
    }
}
