using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.UserMng
{
    public class EmplT : BaseModelT
    {
        /// <summary>  
        /// 사원코드
        /// </summary> 
        public string EmplCode { get; set; }

        /// <summary>  
        /// 부서코드
        /// </summary> 
        public string DeptCode { get; set; }

        /// <summary>
        /// 부서명
        /// </summary>
        public string DeptNm { get; set; }

        /// <summary>  
        /// 사원명
        /// </summary> 
        public string UserNm { get; set; }

        /// <summary>  
        /// 사용자ID
        /// </summary> 
        public string UserId { get; set; }

        /// <summary>  
        /// 비밀번호
        /// </summary> 
        public string Password { get; set; }

        /// <summary>  
        /// 전화번호
        /// </summary> 
        public string Telno { get; set; }

        /// <summary>  
        /// 휴대폰번호
        /// </summary> 
        public string Mbtlnum { get; set; }

        /// <summary>  
        /// 이메일주소
        /// </summary> 
        public string EmailAdres { get; set; }

        /// <summary>  
        /// 직위명
        /// </summary> 
        public string OfcpsNm { get; set; }

        /// <summary>  
        /// 정렬순서
        /// </summary> 
        public int SortOrdr { get; set; }

        /// <summary>  
        /// 직무내용
        /// </summary> 
        public string DtyCn { get; set; }

        /// <summary>  
        /// 사용여부
        /// </summary> 
        public string UseAt { get; set; }

        /// <summary>  
        /// 고용형태명
        /// </summary> 
        public string EmplymStleNm { get; set; }

        /// <summary>  
        /// 재직여부
        /// </summary> 
        public string HffcAt { get; set; }

        /// <summary>  
        /// 입사일자
        /// </summary> 
        public string EncpnDe { get; set; }

        /// <summary>  
        /// 퇴사일자
        /// </summary> 
        public string RetireDe { get; set; }
        
        /// <summary>  
        /// 등록일시
        /// </summary> 
        public DateTime RegistDt { get; set; }

        /// <summary>  
        /// 수정일시
        /// </summary> 
        public DateTime UpdtDt { get; set; }

        /// <summary>  
        /// 더존 부서코드(세금계산서 호출시 이용)
        /// </summary> 
        public string DuzonDeptCode { get; set; }

        /// <summary>  
        /// 더존 사원코드(세금계산서 호출시 이용)
        /// </summary> 
        public string DuzonEmplCode { get; set; }

    }
}
