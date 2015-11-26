using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.UserMng
{
    public class InsttUserT : BaseModelT
    {
        /// <summary>  
        /// 사용자ID
        /// </summary> 
        public string UserId { get; set; }

        /// <summary>  
        /// 기관일련번호
        /// </summary> 
        public long InsttSn { get; set; }

        /// <summary>  
        /// 기관명
        /// </summary> 
        public string InsttNm { get; set; }

        /// <summary>  
        /// 사용자명
        /// </summary> 
        public string UserNm { get; set; }

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
        /// 관리자여부
        /// </summary> 
        public string MngrAt { get; set; }

        /// <summary>  
        /// 기관사용자상태코드
        /// </summary> 
        public string InsttUserSttusCode { get; set; }

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
