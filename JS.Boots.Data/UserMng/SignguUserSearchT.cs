using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.UserMng
{
    public class SignguUserSearchT : BaseSearchT
    {
        /// <summary>  
        /// 사용자ID
        /// </summary> 
        public string SearchUserId { get; set; }

        /// <summary>  
        /// 시도구분코드
        /// </summary> 
        public string SearchAtptSeCode { get; set; }

        /// <summary>  
        /// 구군구분코드
        /// </summary> 
        public string SearchGuGunSeCode { get; set; }

        /// <summary>  
        /// 행정기관명
        /// </summary> 
        public string SearchAdmnstmachNm { get; set; }

        /// <summary>  
        /// 사용자명
        /// </summary> 
        public string SearchUserNm { get; set; }

        /// <summary>  
        /// 전화번호
        /// </summary> 
        public string SearchTelno { get; set; }

        /// <summary>  
        /// 휴대폰번호
        /// </summary> 
        public string SearchMbtlnum { get; set; }

        /// <summary>  
        /// 이메일주소
        /// </summary> 
        public string SearchEmailAdres { get; set; }

        /// <summary>  
        /// 부서명
        /// </summary> 
        public string SearchDeptNm { get; set; }

        /// <summary>  
        /// 직위명
        /// </summary> 
        public string SearchOfcpsNm { get; set; }

        /// <summary>  
        /// 계량업무개시일
        /// </summary> 
        public string SearchMesurJobBeginDe { get; set; }

        /// <summary>  
        /// 계량교육수료일
        /// </summary> 
        public string SearchMesurEdcComplDe { get; set; }

        /// <summary>  
        /// 시군구사용자상태코드
        /// </summary> 
        public string SearchSignguUserSttusCode { get; set; }

        /// <summary>  
        /// 등록일시
        /// </summary> 
        public DateTime SearchRegistDt { get; set; }

        /// <summary>  
        /// 등록자ID
        /// </summary> 
        public string SearchRegisterId { get; set; }

        /// <summary>  
        /// 수정일시
        /// </summary> 
        public DateTime SearchUpdtDt { get; set; }

        /// <summary>  
        /// 수정자ID
        /// </summary> 
        public string SearchUpdusrId { get; set; }
    }
}
