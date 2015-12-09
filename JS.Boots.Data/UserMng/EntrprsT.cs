using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.UserMng
{
    public class EntrprsT : BaseModelT
    {
        /// <summary>  
        /// 기업일련번호
        /// </summary> 
        public long EntrprsSn { get; set; }

        /// <summary>  
        /// 대표자명
        /// </summary> 
        public string RprsntvNm { get; set; }

        /// <summary>  
        /// 기업명
        /// </summary> 
        public string EntrprsNm { get; set; }

        /// <summary>  
        /// 사업자등록번호
        /// </summary> 
        public string Bizrno { get; set; }

        /// <summary>  
        /// 대표전화번호
        /// </summary> 
        public string ReprsntTelno { get; set; }

        /// <summary>
        /// 대표팩스번호
        /// </summary>
        public string ReprsntFxNum { get; set; }

        /// <summary>  
        /// 제조업여부
        /// </summary> 
        public string MfcrtrAt { get; set; }

        /// <summary>  
        /// 수입업여부
        /// </summary> 
        public string IrtbAt { get; set; }

        /// <summary>  
        /// 수리업여부
        /// </summary> 
        public string RepairIndutyAt { get; set; }

        /// <summary>  
        /// 계량증명업여부
        /// </summary> 
        public string MesurProofIndutyAt { get; set; }

        /// <summary>
        /// 계량기사용자여부
        /// </summary>
        public string MrnrEmplyrAt { get; set; }

        /// <summary>
        /// ONLY 계량기사용자
        /// </summary>
        public string MrnrEmplyrAtOnly { get; set; }

        /// <summary>
        /// 제조등록번호명
        /// </summary>
        public string MnfcturRegistNoNm { get; set; }

        /// <summary>
        /// 제조등록일자
        /// </summary>
        public string MnfcturRegistDe { get; set; }

        /// <summary>
        /// 계량증명업등록번호명
        /// </summary>
        public string MesurProofRegistNoNm { get; set; }

        /// <summary>
        /// 계량증명업등록일자
        /// </summary>
        public string MesurProofRegistDe { get; set; }

        /// <summary>
        /// 시도접수여부
        /// </summary>
        public string AtptRceptAt { get; set; }

        /// <summary>
        /// 회원여부
        /// </summary>
        public string MberAt { get; set; }

        /// <summary>
        /// 업체구분명
        ///   예 : 제조업, 수입업, 수리업
        /// </summary>
        public string EnterpriseSectionName { get; set; }

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

        /// <summary>  
        /// 기존비밀번호
        /// </summary> 
        public string OldPassword { get; set; }

        /// <summary>
        /// 사업장주소
        /// </summary>
        public EntrprsAdresT BizEntrprsAdresT { get; set; }

        /// <summary>
        /// 기업주소 리스트
        /// </summary>
        public IList<EntrprsAdresT> entrprsAdresList;

        /// <summary>
        /// 제조계량기정보 업데이트 여부
        /// </summary>
        public bool IsMnfcturUpdate { get; set; }

        /// <summary>
        /// 계량증명업정보 업데이트 여부
        /// </summary>
        public bool IsProofUpdate { get; set; }

        /// <summary>
        /// 기업인정정보 업데이트 여부
        /// </summary>
        public bool IsRcognInfoUpdate { get; set; }

        /// <summary>
        /// 변경일자
        /// </summary>
        public string changeDe { get; set; }

        /// <summary>
        /// 변경내용
        /// </summary>
        public string changeCn { get; set; }

        /// <summary>
        /// 홈페이지
        /// </summary>
        public string HmpgUrl { get; set; }

        /// <summary>  
        /// 인정일자
        /// </summary> 
        public string RcognDe { get; set; }

        /// <summary>
        /// 업체구분
        /// </summary>
        public string RcognSeCodeNm { get; set; }
    }  
}
