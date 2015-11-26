using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.Product
{
    public class ProductSearchT : BaseSearchT
    {
        /// <summary>
        /// 계량기 구분 코드
        /// </summary>
        public string MrnrSeCode { get; set; }

        /// <summary>
        /// 제조/수입사
        /// </summary>
        public string EntrpsNm { get; set; }

        /// <summary>
        /// 검정종료 시작일자 (= 완료일) 
        /// </summary>
        public string AthrzEndDe_Start { get; set; }

        /// <summary>
        /// 검정종료 종료일자 (= 완료일) 
        /// </summary>
        public string AthrzEndDe_End { get; set; }

        /// <summary>
        /// 사용처 (정기검사 - 상호명)
        /// </summary>
        public string MtltyNm { get; set; }

        /// <summary>
        /// 형식승인승인번호
        /// </summary>
        public string FomConfmConfmNo { get; set; }

        /// <summary>
        /// 기물번호
        /// </summary>
        public string VesslNo { get; set; }

        //public ProductSearchT()
        //{
        //    MrnrSeCode = "AB001001";
        //}
    }
}
