﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.UserMng
{
    public class IndvdlUserT : BaseModelT
    {
        /// <summary>
        /// 아이핀고유번호
        /// </summary>
        public string IpinInnb { get; set; }

        /// <summary>  
        /// 사용자ID
        /// </summary> 
        public string UserId { get; set; }

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
        /// 생년월일
        /// </summary> 
        public string Brthdy { get; set; }

        /// <summary>  
        /// 주소구분코드
        /// </summary> 
        public string AdresSeCode { get; set; }

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
        /// 비밀번호힌트구분코드
        /// </summary> 
        public string PasswordHintSeCode { get; set; }

        /// <summary>  
        /// 비밀번호힌트정답
        /// </summary> 
        public string PasswordHintCnsr { get; set; }

        /// <summary>  
        /// 이메일수신여부
        /// </summary> 
        public string EmailRecptnAt { get; set; }

        /// <summary>  
        /// SMS수신여부
        /// </summary> 
        public string SmsRecptnAt { get; set; }

        /// <summary>  
        /// 개인사용자상태코드
        /// </summary> 
        public string IndvdlUserSttusCode { get; set; }

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

        /// <summary>  
        /// 비밀번호
        /// </summary> 
        public string Password { get; set; }

    }
}
