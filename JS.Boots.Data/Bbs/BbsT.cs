using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.Bbs
{
    /// <summary>
    /// 게시판 Model
    /// </summary>
    public class BbsT : BaseModelT
    {
        /// <summary>  
        /// 게시판 일련번호
        /// </summary> 
        public long BbsSn { get; set; }

        /// <summary>  
        /// 게시판명
        /// </summary> 
        public string BbsNm { get; set; }

        /// <summary>  
        /// 사용여부
        /// </summary> 
        public string UseAt { get; set; }

        /// <summary>  
        /// 코멘트여부
        /// </summary> 
        public string CommentAt { get; set; }

        /// <summary>  
        /// 계층여부
        /// </summary> 
        public string SclsrtAt { get; set; }

        /// <summary>  
        /// 공개여부
        /// </summary> 
        public string OthbcAt { get; set; }

        /// <summary>  
        /// 게시판유형코드
        /// </summary> 
        public string BbsTyCode { get; set; }

        /// <summary>  
        /// 진행상태관리여부
        /// </summary> 
        public string ProgrsSttusManageAt { get; set; }

        /// <summary>  
        /// 첨부파일여부
        /// </summary> 
        public string AtchmnflAt { get; set; }

        /// <summary>  
        /// 첨부파일수
        /// </summary> 
        public long AtchmnflCo { get; set; }

        /// <summary>  
        /// 첨부파일최대사이즈(MB)
        /// </summary> 
        public long AtchmnflMxmmSize { get; set; }

        /// <summary>  
        /// 등록일시
        /// </summary> 
        public DateTime RegistDt { get; set; }

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

        /// <summary>
        /// 게시판계량기 구분코드 사용여부(Y/N)
        /// </summary>
        public string BbsMrnrSeCodeUseAt { get; set; }
    }
}
