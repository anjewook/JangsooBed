using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.OptionWorkMng
{
    public class DeptT : BaseModelT
    {
        /// <summary>  
        /// 부서를 구분하는 유일한 값
        /// </summary> 
        public string DeptCode { get; set; }

        /// <summary>  
        /// 더존부서코드
        /// </summary> 
        public string DuzonDeptCode { get; set; }

        /// <summary>  
        /// 상위부서코드
        /// </summary> 
        public string UpperDeptCode { get; set; }

        /// <summary>  
        /// 부서명
        /// </summary> 
        public string DeptNm { get; set; }

        /// <summary>  
        /// 사용여부
        /// </summary> 
        public string UseAt { get; set; }

        /// <summary>  
        /// 정렬순서
        /// </summary> 
        public long SortOrdr { get; set; }

        /// <summary>  
        /// 직무내용
        /// </summary> 
        public string DtyCn { get; set; }

        /// <summary>  
        /// 부서장사원코드
        /// </summary> 
        public string DprlrEmplCode { get; set; }

        /// <summary>  
        /// 등록일시
        /// </summary> 
        public DateTime RegistDt { get; set; }

        /// <summary>  
        /// 수정일시
        /// </summary> 
        public DateTime UpdtDt { get; set; }

    }
}
