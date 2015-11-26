using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.UserMng
{
    public class SignguUserT : BaseModelT
    {
        /// <summary>  
        /// 사용자ID
        /// </summary> 
        public string UserId { get; set; }

        /// <summary>  
        /// 시도구분코드
        /// </summary> 
        public string AtptSeCode { get; set; }

        /// <summary>  
        /// 시도구분코드명
        /// </summary> 
        public string AtptSeCodeNm { get; set; }

        /// <summary>  
        /// 구군구분코드
        /// </summary> 
        public string GuGunSeCode { get; set; }

        /// <summary>  
        /// 구군구분코드명
        /// </summary> 
        public string GuGunSeCodeNm { get; set; }

        /// <summary>  
        /// 행정기관명
        /// </summary> 
        public string AdmnstmachNm { get; set; }

        /// <summary>  
        /// 주소구분코드
        /// </summary> 
        public string AdresSeCode { get; set; }

        /// <summary>  
        /// 주소구분코드명
        /// </summary> 
        public string AdresSeCodeNm { get; set; }

        /// <summary>  
        /// 우편번호
        /// </summary> 
        public string Zip { get; set; }

        /// <summary>  
        /// 기본주소
        /// </summary> 
        public string BassAdres { get; set; }

        /// <summary>  
        /// 상세주소
        /// </summary> 
        public string DetailAdres { get; set; }

        /// <summary>  
        /// 사용자명
        /// </summary> 
        public string UserNm { get; set; }

        /// <summary>  
        /// 전화번호
        /// </summary> 
        public string Telno { get; set; }

        /// <summary>  
        /// 팩스번호
        /// </summary> 
        public string Fxnum { get; set; }

        /// <summary>  
        /// 휴대폰번호
        /// </summary> 
        public string Mbtlnum { get; set; }

        /// <summary>  
        /// 이메일주소
        /// </summary> 
        public string EmailAdres { get; set; }

        /// <summary>  
        /// 부서명
        /// </summary> 
        public string DeptNm { get; set; }

        /// <summary>  
        /// 직위명
        /// </summary> 
        public string OfcpsNm { get; set; }

        /// <summary>  
        /// 계량업무개시일
        /// </summary> 
        public string MesurJobBeginDe { get; set; }

        /// <summary>  
        /// 계량교육수료일
        /// </summary> 
        public string MesurEdcComplDe { get; set; }

        /// <summary>  
        /// 시군구사용자상태코드
        /// </summary> 
        public string SignguUserSttusCode { get; set; }

        /// <summary>  
        /// 시군구사용자상태코드명
        /// </summary> 
        public string SignguUserSttusCodeNm { get; set; }

        /// <summary>  
        /// 등록일시
        /// </summary> 
        public DateTime RegistDt { get; set; }

        /// <summary>  
        /// 등록자ID
        /// </summary> 
        public string RegisterId { get; set; }

        /// <summary>  
        /// 수정일시
        /// </summary> 
        public DateTime UpdtDt { get; set; }

        /// <summary>  
        /// 수정자ID
        /// </summary> 
        public string UpdusrId { get; set; }

        /// <summary>  
        /// 등록자구분코드
        /// </summary> 
        public string RegisterSeCode { get; set; }

        /// <summary>  
        /// 수정자구분코드
        /// </summary> 
        public string UpdusrSeCode { get; set; }

        /// <summary>  
        /// 등록자명
        /// </summary> 
        public string RegisterNm { get; set; }

        /// <summary>  
        /// 수정자명
        /// </summary> 
        public string UpdusrNm { get; set; }

    }
}
