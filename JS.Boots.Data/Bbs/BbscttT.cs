using JS.Boots.Data.Atchmnfl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.Bbs
{
    public class BbscttT : BaseModelT
    {
        /// <summary>  
        /// 게시글일련번호
        /// </summary> 
        public long BbscttSn { get; set; }

        /// <summary>  
        /// 게시판일련번호
        /// </summary> 
        public long BbsSn { get; set; }

        /// <summary>  
        /// 부모게시글일련번호
        /// </summary> 
        public long ParntsBbscttSn { get; set; }

        /// <summary>  
        /// 그룹번호
        /// </summary> 
        public long GroupNo { get; set; }

        /// <summary>  
        /// 깊이번호
        /// </summary> 
        public long DpNo { get; set; }

        /// <summary>  
        /// 정렬순서
        /// </summary> 
        public long SortOrdr { get; set; }

        /// <summary>  
        /// 제목명
        /// </summary> 
        public string SjNm { get; set; }

        /// <summary>  
        /// 조회수
        /// </summary> 
        public long Rdcnt { get; set; }

        /// <summary>  
        /// 삭제여부
        /// </summary> 
        public string DeleteAt { get; set; }

        /// <summary>  
        /// 등록일시
        /// </summary> 
        public DateTime RegistDt { get; set; }

        /// <summary>  
        /// 등록자ID
        /// </summary> 
        public string RegisterId { get; set; }

        /// <summary>  
        /// 등록자구분코드
        /// </summary> 
        public string RegisterSeCode { get; set; }

        /// <summary>
        /// 등록자명
        /// </summary>
        public string UserName { get; set; }

        /// <summary>  
        /// 수정일시
        /// </summary> 
        public DateTime UpdtDt { get; set; }

        /// <summary>  
        /// 수정자ID
        /// </summary> 
        public string UpdusrId { get; set; }

        /// <summary>  
        /// 수정자구분코드
        /// </summary> 
        public string UpdusrSeCode { get; set; }  

        /// <summary>
        /// 진행상태구분코드
        /// </summary>
        public string ProgrsSttusSeCode { get; set; }

        /// <summary>
        /// 진행상태구분코드명
        /// </summary>
        public string ProgrsSttusSeCodeName { get; set; }

        /// <summary>
        /// 게시판계량기 구분코드
        /// </summary>
        public string BbsMrnrSeCode { get; set; }

        /// <summary>
        /// 게시판계량기 구분코드명
        /// </summary>
        public string BbsMrnrSeCodeName { get; set; }

        /// <summary>
        /// 게시글내용
        /// </summary>
        public string Contents { get; set; }

        /// <summary>
        /// 게시글 코멘트 목록
        /// </summary>
        public IList<BbscttCommentT> BbscttCommentList { get; set; }

        /// <summary>
        /// 게시글 첨부파일 목록
        /// </summary>
        public IList<BbscttAtchmnflT> AtchmnflList { get; set; }

        /// <summary>
        /// 삭제할 첨부파일 일련번호 배열
        /// </summary>
        public string[] DeleteAtchmnflSn { get; set; }

        /// <summary>
        /// 공통파일저장
        /// </summary>
        public AtchmnflArgsT atchmnflArgsT;

        /// <summary>
        /// 게시판명
        /// </summary>
        public string BbsNm { get; set; }

        /// <summary>
        /// 등록된 시간
        /// </summary>
        public long RegistHour { get; set; }

        /// <summary>  
        /// 등록일시 문자열
        /// </summary> 
        public string RegistDtToString { get; set; }

        /// <summary>
        /// 등록가능 여부
        /// </summary>
        public bool IsCreate { get; set; }

        /// <summary>
        /// 수정가능 여부
        /// </summary>
        public bool IsUpdate { get; set; }

        /// <summary>
        /// 삭제가능 여부
        /// </summary>
        public bool IsDelete { get; set; }

        /// <summary>
        /// 댓글 갯수
        /// </summary>
        public long CommentCnt { get; set; }

        /// <summary>
        /// 제목명 메인에서 사용
        ///  - 길이가 길면 문자열을 자른뒤 ... 을 붙여준다.
        /// </summary>
        public string SjNmUseMain
        {
            get
            {
                int titleLength = 20;

                if (!String.IsNullOrWhiteSpace(SjNm))
                {
                    if (SjNm.Length > titleLength)
                    {
                        return SjNm.Substring(0, titleLength) + "...";
                    }
                    else
                    {
                        return SjNm;
                    }
                }
                else
                {
                    return "";
                }
            }
        }

        public string SjNmUseAdminMain
        {
            get
            {
                int titleLength = 13;

                if (!String.IsNullOrWhiteSpace(SjNm))
                {
                    if (SjNm.Length > titleLength)
                    {
                        return SjNm.Substring(0, titleLength) + "...";
                    }
                    else
                    {
                        return SjNm;
                    }
                }
                else
                {
                    return "";
                }
            }
        }





    }
}
