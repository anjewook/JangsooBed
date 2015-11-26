using JS.Boots.Data.Atchmnfl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.OptionWorkMng
{
    public class JobContactT : BaseModelT
    {
        /// <summary>  
        /// 업무연락일련번호
        /// </summary> 
        public long JobContactSn { get; set; }

        /// <summary>  
        /// 대상부서코드
        /// </summary> 
        public string TrgetDeptCode { get; set; }

        /// <summary>
        /// 부서명
        /// </summary>
        public string DeptNm { get; set; }

        /// <summary>  
        /// 대상사원코드
        /// </summary> 
        public string TrgetEmplCode { get; set; }

        /// <summary>  
        /// 대상명
        /// </summary> 
        public string TrgetNm { get; set; }

        /// <summary>  
        /// 제목명
        /// </summary> 
        public string SjNm { get; set; }

        /// <summary>  
        /// 내용
        /// </summary> 
        public string Contents { get; set; }

        /// <summary>  
        /// 등록일시
        /// </summary> 
        public DateTime RegistDt { get; set; }

        /// <summary>
        /// 등록일시 문자열
        /// </summary>
        public string RegistDtToString { get; set; }

        /// <summary>  
        /// 등록자ID
        /// </summary> 
        public string RegisterId { get; set; }

        /// <summary>
        /// 등록자명
        /// </summary>
        public string UserName { get; set; }

        /// <summary>  
        /// 등록자구분코드
        /// </summary> 
        public string RegisterSeCode { get; set; }

        /// <summary>  
        /// 수정일시
        /// </summary> 
        public DateTime UpdtDt { get; set; }

        /// <summary>  
        /// 수정자ID
        /// </summary> 
        public string UpdusrId { get; set; }

        /// <summary>  
        /// 수정자구분코드
        /// </summary> 
        public string UpdusrSeCode { get; set; }  

        /// <summary>
        /// 공통파일저장
        /// </summary>
        public AtchmnflArgsT atchmnflArgsT;

        /// <summary>
        /// 첨부파일 List
        /// </summary>
        public IList<JobContacttnAtchmnflT> AtchmnflList { get; set; }

    }  
}
