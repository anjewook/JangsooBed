using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.OptionWorkMng
{
    /// <summary>
    /// FeeSeCode + FeeSn : PK
    /// </summary>
    public class FeeManageT : BaseModelT
    {
        /// <summary>  
        /// 수수료구분코드(공통코드)
        /// </summary> 
        public string FeeSeCode { get; set; }

        /// <summary>  
        /// 수수료구분코드명
        /// </summary> 
        public string FeeSeCodeNm { get; set; }

        /// <summary>  
        /// 수수료일련번호
        /// </summary> 
        public long FeeSn { get; set; }

        /// <summary>  
        /// 수수료명
        /// </summary> 
        public string FeeNm { get; set; }

        /// <summary>  
        /// 규격명
        /// </summary> 
        public string StndrdNm { get; set; } 

        /// <summary>  
        /// 수수료금액
        /// </summary> 
        public long FeeAmount { get; set; }

        /// <summary>  
        /// 비고
        /// </summary> 
        public string Rm { get; set; }

        /// <summary>  
        /// 삭제여부
        /// </summary> 
        public string DeleteAt { get; set; }  

        /// <summary>  
        /// 등록일시
        /// </summary> 
        public DateTime RegistDt { get; set; }

        /// <summary>  
        /// 등록자구분코드
        /// </summary> 
        public string RegisterSeCode { get; set; }

        /// <summary>  
        /// 등록자ID
        /// </summary> 
        public string RegisterId { get; set; }

        /// <summary>  
        /// 수정일시
        /// </summary> 
        public DateTime UpdtDt { get; set; }

        /// <summary>  
        /// 수정자구분코드
        /// </summary> 
        public string UpdusrSeCode { get; set; }

        /// <summary>  
        /// 수정자ID
        /// </summary> 
        public string UpdusrId { get; set; }

    }
}
