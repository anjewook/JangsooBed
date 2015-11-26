using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JS.Boots.Security;

namespace JS.Boots.Data.UserMng
{
    public class ProfileT : BaseModelT
    {
        public ProfileT()
        {
            IsK0001 = false;    //접수담당자        
            IsK0002 = false;  	//회계담당자        
            IsK0003 = false;  	//접수승인자        
            IsK0004 = false;  	//검정담당자        
            IsK0005 = false;  	//검정책임자        
            IsK0006 = false;  	//형식승인담당자    
            IsK0007 = false;  	//형식승인책임자    
            IsK0008 = false;  	//총괄책임자        
            IsK0009 = false;  	//시스템관리자      
            IsI0001 = false;  	//형식승인기관      
            IsI0002 = false;  	//검정기관          
            IsI0003 = false;  	//계량기관리사업자  
            IsI0004 = false;  	//자체수리자        
            IsI0005 = false;  	//자체검정사업자    
            IsI0006 = false;  	//자체정기검사사업자
            IsA0001 = false;  	//개인회원          
            IsE0001 = false;  	//등록업체          
            IsE0002 = false;  	//계량기사용자      
            IsS0001 = false;  	//계량담당공무원    
            IsR0001 = false;  	//중앙공무원    
        }

        #region 공통

        /// <summary>
        /// 사용자 IP
        /// </summary>
        public string UserHostAddress { get; set; }

        /// <summary>
        /// 사용자유형
        /// </summary>
        public UserType UserType { get; set; }
        
        /// <summary>
        /// 사용자ID
        /// </summary>
        public string UserId { get; set; }
        
        /// <summary>
        /// 사용자명
        /// </summary>
        public string UserNm { get; set; }
        
        /// <summary>
        /// 비밀번호
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 사용자 구분코드
        /// </summary>
        public string UserSeCode { get; set; }

        /// <summary>
        /// 사용자 구분명
        /// </summary>
        public string UserSeName { get; set; }

        /// <summary>
        /// 전화번호
        /// </summary>
        public string TelNumber { get; set; }

        /// <summary>
        /// 휴대폰
        /// </summary>
        public string MobileNumber { get; set; }

        /// <summary>
        /// 이메일
        /// </summary>
        public string Email { get; set; }

        /// <summary>  
        /// 사업자등록번호
        /// </summary> 
        public string Bizrno { get; set; }

        /// <summary>
        /// 권한그룹목록
        /// </summary>
        public IList<string> AuthorGroupList { get; set; }

        /// <summary>
        /// 비밀번호 변경 경과 여부
        /// </summary>
        public string PassChangeElapseAt { get; set; }

        #endregion

        #region 개인사용자

        /// <summary>
        /// SMS 수신여부
        /// </summary>
        public string SmsRecptnAt { get; set; }

        /// <summary>
        /// 이메일 수신여부
        /// </summary>
        public string EmailRecptnAt { get; set; }


        #endregion

        #region 기업사용자

        /// <summary>
        /// 기업일련번호
        /// </summary>
        public long EntrprsSn { get; set; }

        /// <summary>
        /// 기업명
        /// </summary>
        public string EntrprsNm { get; set; }

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
        /// 관리자여부
        /// </summary> 
        public string MngrAt { get; set; }

        /// <summary>
        /// 대표자명
        /// </summary>
        public string RprsntvNm { get; set; }

        /// <summary>
        /// 대표자전화번호
        /// </summary>
        public string ReprsntTelno { get; set; }

        /// <summary>
        /// 대표자팩스번호
        /// </summary>
        public string ReprsntFxnum { get; set; }

        /// <summary>
        /// 업체구분명
        ///   예 : 제조업, 수입업, 수리업
        /// </summary>
        public string EnterpriseSectionName { get; set; }

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
        /// 기업 사업장주소 목록
        /// </summary>
        public IList<EntrprsAdresT> EntrprsBplcAdresList { get; set; }

        /// <summary>
        /// 기업 공장주소  목록
        /// </summary>
        public IList<EntrprsAdresT> EntrprsFctryAdresList { get; set; }

        #endregion

        #region 기관사용자

        /// <summary>  
        /// 기관일련번호
        /// </summary> 
        public long InsttSn { get; set; }

        /// <summary>  
        /// 기관명
        /// </summary> 
        public string InsttNm { get; set; }

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

        #endregion

        #region 시군구사용자

        /// <summary>  
        /// 시도구분코드
        /// </summary> 
        public string AtptSeCode { get; set; }

        /// <summary>  
        /// 구군구분코드
        /// </summary> 
        public string GuGunSeCode { get; set; }

        /// <summary>  
        /// 행정기관명
        /// </summary> 
        public string AdmnstmachNm { get; set; }

        #endregion

        #region KTC담당자

        /// <summary>
        /// 부서코드
        /// </summary>
        public string DeptCode { get; set; }

        /// <summary>
        /// 부서명
        /// </summary>
        public string DeptNm { get; set; }

        /// <summary>
        /// 사원코드
        /// </summary>
        public string EmplCode { get; set; }

        /// <summary>
        /// 더존 부서코드 (세금계산서 호출시 이용)
        /// </summary>
        public string DuzonDeptCode { get; set; }

        /// <summary>
        /// 더존 사원코드 (세금계산서 호출시 이용)
        /// </summary>
        public string DuzonEmplCode { get; set; }

        #endregion

        #region 권한그룹별 권한 여부

        /// <summary>
        /// 접수담당자 여부
        /// </summary>
        public bool IsK0001 { get; set; }

        /// <summary>
        /// 회계담당자 여부
        /// </summary>
        public bool IsK0002 { get; set; }

        /// <summary>
        /// 접수승인자 여부
        /// </summary>
        public bool IsK0003 { get; set; }

        /// <summary>
        /// 검정담당자 여부
        /// </summary>
        public bool IsK0004 { get; set; }

        /// <summary>
        /// 검정책임자 여부
        /// </summary>
        public bool IsK0005 { get; set; }

        /// <summary>
        /// 형식승인담당자 여부
        /// </summary>
        public bool IsK0006 { get; set; }

        /// <summary>
        /// 형식승인책임자 여부
        /// </summary>
        public bool IsK0007 { get; set; }

        /// <summary>
        /// 총괄책임자 여부
        /// </summary>
        public bool IsK0008 { get; set; }

        /// <summary>
        /// 시스템관리자
        /// </summary>
        public bool IsK0009 { get; set; }

        /// <summary>
        /// 형식승인기관 여부
        /// </summary>
        public bool IsI0001 { get; set; }

        /// <summary>
        /// 검정기관 여부
        /// </summary>
        public bool IsI0002 { get; set; }

        /// <summary>
        /// 계량기관리사업자 여부
        /// </summary>
        public bool IsI0003 { get; set; }

        /// <summary>
        /// 자체수리자 여부
        /// </summary>
        public bool IsI0004 { get; set; }

        /// <summary>
        /// 자체검정사업자 여부
        /// </summary>
        public bool IsI0005 { get; set; }

        /// <summary>
        /// 자체정기검사사업자 여부
        /// </summary>
        public bool IsI0006 { get; set; }

        /// <summary>
        /// 개인회원 여부
        /// </summary>
        public bool IsA0001 { get; set; }

        /// <summary>
        /// 등록업체 여부
        /// </summary>
        public bool IsE0001 { get; set; }

        /// <summary>
        /// 계량기사용자 여부
        /// </summary>
        public bool IsE0002 { get; set; }

        /// <summary>
        /// 계량담당공무원 여부
        /// </summary>
        public bool IsS0001 { get; set; }

        /// <summary>
        /// 중앙공무원 여부
        /// </summary>
        public bool IsR0001 { get; set; }

        #endregion


        public string UserTypeCode 
        {
            get
            {
                return Security.Security.UserTypeChange(UserType);
            }
            set
            {
                UserType = Security.Security.UserTypeChange(value);
            }
        }
    }
}
