using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ArchFx.ExtensionMethod;

namespace JS.Boots.Data.Product
{
    public class ProductT : BaseModelT
    {
        /// <summary>
        /// 계량기 구분 코드
        /// </summary>
        public string MrnrSeCode { get; set; }

        /// <summary>
        /// 계량기 구분 코드명
        /// </summary>
        public string MrnrSeCodeName { get; set; }

        /// <summary>
        /// 기물번호
        /// </summary>
        public string VesslNo { get; set; }

        /// <summary>
        /// 형식승인승인번호
        /// </summary>
        public string FomConfmConfmNo { get; set; }

        /// <summary>
        /// 제조/수입사
        /// </summary>
        public string EntrpsNm { get; set; }

        /// <summary>
        /// 사용처 (정기검사 - 상호명)
        /// </summary>
        public string MtltyNm { get; set; }

        /// <summary>
        /// 검정종료일자 (= 완료일)
        /// </summary>
        public string AthrzEndDe { get; set; }
        
        public long RowNumber { get; set; }

        public long TotalCount { get; set; }


        /// <summary>
        /// 형식승인 모델명 
        /// </summary>
        public string ModelNm { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FomConfmInsttSeCodeName { get; set; }

        /// <summary>
        /// 최종 승인 일자
        /// </summary>
        public string LastConfDe { get; set; }

        /// <summary>
        /// 검정구분명
        /// </summary>
        public string AthrzSeCodeName { get; set; }

        /// <summary>
        /// 검정결과
        /// </summary>
        public string SmFatherJdgmntAt { get; set; }

        /// <summary>
        /// 검정기관
        /// </summary>
        public string InsttNm { get; set; }

        /// <summary>
        /// 형식승인일련번호
        /// </summary>
        public long FomConfmSn { get; set; }
    }
}
