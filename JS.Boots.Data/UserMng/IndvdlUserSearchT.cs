using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.UserMng
{
    public class IndvdlUserSearchT : BaseSearchT
    {
        /// <summary>  
        /// 사용자ID
        /// </summary> 
        public string SearchUserId { get; set; }

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
        /// 생년월일
        /// </summary> 
        public string SearchBrthdy { get; set; }

        /// <summary>  
        /// 주소구분코드
        /// </summary> 
        public string SearchAdresSeCode { get; set; }

        /// <summary>  
        /// 우편번호
        /// </summary> 
        public string SearchZip { get; set; }

        /// <summary>  
        /// 기본주소
        /// </summary> 
        public string SearchBassAdres { get; set; }

        /// <summary>  
        /// 상세주소
        /// </summary> 
        public string SearchDetailAdres { get; set; }

        /// <summary>  
        /// 비밀번호힌트구분코드
        /// </summary> 
        public string SearchPasswordHintSeCode { get; set; }

        /// <summary>  
        /// 비밀번호힌트정답
        /// </summary> 
        public string SearchPasswordHintCnsr { get; set; }

        /// <summary>  
        /// 이메일수신여부
        /// </summary> 
        public string SearchEmailRecptnAt { get; set; }

        /// <summary>  
        /// SMS수신여부
        /// </summary> 
        public string SearchSmsRecptnAt { get; set; }

        /// <summary>  
        /// 개인사용자상태코드
        /// </summary> 
        public string SearchIndvdlUserSttusCode { get; set; }

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
