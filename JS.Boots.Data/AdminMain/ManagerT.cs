using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.AdminMain
{
    public class ManagerT : BaseModelT
    {
        /// <summary>  
        /// SEQ 번호
        /// </summary> 
        public long ManagerSn { get; set; }

        /// <summary>  
        /// 일련번호
        /// </summary> 
        public long Rum { get; set; }

        /// <summary>  
        /// 관리자코드
        /// </summary> 
        public long ManagerCode { get; set; }

        /// <summary>  
        /// 관리자명
        /// </summary> 
        public string ManagerNm { get; set; }

        /// <summary>
        /// 관리자 직급명
        /// </summary>
        public string ManagerRankNm { get; set; }

        /// <summary>
        /// 관리자직급 코드
        /// </summary>
        public string ManagerRank { get; set; }

        /// <summary>
        /// 소속부서명
        /// </summary>
        public string ManagerPostNm { get; set; }

        /// <summary>
        /// 소속부서코드
        /// </summary>
        public string ManagerPost { get; set; }

        /// <summary>
        /// 관리자ID
        /// </summary>
        public string ManagerID { get; set; }

        /// <summary>
        /// 관리자PassWord
        /// </summary>
        public string ManagerPw { get; set; }

        /// <summary>
        /// 관리자 사업자ID
        /// </summary>
        public string ManagerBizID { get; set; }

        /// <summary>
        /// 관리자전화번호
        /// </summary>
        public string ManagerTel { get; set; }

        /// <summary>
        /// 관리자전화번호
        /// </summary>
        public string ManagerTel1 { get; set; }

        /// <summary>
        /// 관리자전화번호
        /// </summary>
        public string ManagerTel2 { get; set; }

        /// <summary>
        /// 관리자전화번호
        /// </summary>
        public string ManagerTel3 { get; set; }

        /// <summary>
        /// 관리자휴대전화번호
        /// </summary>
        public string ManagerHp { get; set; }

        /// <summary>
        /// 관리자휴대전화번호
        /// </summary>
        public string ManagerHp1 { get; set; }

        /// <summary>
        /// 관리자휴대전화번호
        /// </summary>
        public string ManagerHp2 { get; set; }

        /// <summary>
        /// 관리자휴대전화번호
        /// </summary>
        public string ManagerHp3 { get; set; }

        /// <summary>  
        /// 등록일시
        /// </summary> 
        public string RegiDate { get; set; }

        /// <summary>
        /// 권한정상여부
        /// </summary>
        public string RightUse { get; set; }

        /// <summary>
        /// 상세보기 여부
        /// </summary>
        public string RightRegi { get; set; }

        /// <summary>  
        /// 관리자 이메일
        /// </summary> 
        public string ManagerEmail { get; set; }

        /// <summary>  
        /// 관리자 이메일1
        /// </summary> 
        public string ManagerEmail1 { get; set; }

        /// <summary>  
        /// 관리자 이메일2
        /// </summary> 
        public string ManagerEmail2 { get; set; }

        /// <summary>  
        /// 사용여부
        /// </summary> 
        public string UseAt { get; set; }

        /// <summary>  
        /// 계층여부
        /// </summary> 
        public string SclsrtAt { get; set; }

        /// <summary>  
        /// 공개여부
        /// </summary> 
        public string OthbcAt { get; set; }

        /// <summary>  
        /// 유형코드
        /// </summary> 
        public string ManagerTyCode { get; set; }

        /// <summary>  
        /// 등록자구분코드
        /// </summary> 
        public string RegisterSeCode { get; set; }

        /// <summary>  
        /// 등록자ID
        /// </summary> 
        public string RegisterId { get; set; }

        /// <summary>
        /// 등록자명
        /// </summary>
        public string RegisterNm { get; set; }

        /// <summary>  
        /// 수정일시
        /// </summary> 
        public DateTime UpdtDt { get; set; }

        /// <summary>  
        /// 수정자구분코드
        /// </summary> 
        public string UpdusrSeCode { get; set; }

        /// <summary>  
        /// 수정자ID
        /// </summary> 
        public string UpdusrId { get; set; }


        public string Message { get; set; }
    }
}
