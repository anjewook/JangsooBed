using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.UserMng
{
    public class InsttT : BaseModelT
    {
        /// <summary>  
        /// 기관일련번호
        /// </summary> 
        public long InsttSn { get; set; }

        /// <summary>  
        /// 기관명
        /// </summary> 
        public string InsttNm { get; set; }

        /// <summary>  
        /// 사업자등록번호
        /// </summary> 
        public string Bizrno { get; set; }

        /// <summary>  
        /// 대표자명
        /// </summary> 
        public string RprsntvNm { get; set; }

        /// <summary>  
        /// 대표전화번호
        /// </summary> 
        public string ReprsntTelno { get; set; }

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
        /// 기관구분코드
        /// </summary> 
        public string InsttSeCode { get; set; }

        /// <summary>  
        /// 형식승인기관여부
        /// </summary> 
        public string FomConfmInsttAt { get; set; }

        /// <summary>  
        /// 검정기관여부
        /// </summary> 
        public string AthrzInsttAt { get; set; }

        /// <summary>  
        /// 기관상태코드
        /// </summary> 
        public string InsttSttusCode { get; set; }

        /// <summary>  
        /// 지정번호명
        /// </summary> 
        public string AppnNoNm { get; set; }

        /// <summary>  
        /// 지정일자
        /// </summary> 
        public string ApntDe { get; set; }

        /// <summary>  
        /// 검정 지정번호명
        /// </summary> 
        public string AthrzAppnNoNm { get; set; }

        /// <summary>  
        /// 검정 지정일자
        /// </summary> 
        public string AthrzApntDe { get; set; }

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
        /// 지정신청분야 건 수
        /// </summary>
        public int AppnReqstRealmCount { get; set; }

        /// <summary>
        /// 지정신청분야명
        /// </summary>
        public string AppnReqstRealmNm { get; set; }

        /// <summary>
        /// 지정신청분야 목록
        /// </summary>
        public IList<AppnReqstRealmT> AppnReqstRealmList { get; set; }

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
        /// 비밀번호
        /// </summary> 
        public string Password { get; set; }

    }
}
