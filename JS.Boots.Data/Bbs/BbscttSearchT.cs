using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.Bbs
{
    public class BbscttSearchT : BaseSearchT
    {
        /// <summary>
        /// 페이지번호
        /// </summary>
        //public long Page { get; set; }

        /// <summary>
        /// 게시판번호
        /// </summary>
        public long BbsSn { get; set; }

        /// <summary>
        /// 게시글번호
        /// </summary>
        public long BbscttSn { get; set; }

        /// <summary>
        /// 계층형 게시판여부
        /// </summary>
        public string SclsrtAt { get; set; }

        /// <summary>
        /// 답변글 등록여부
        /// </summary>
        public string ReplyYn { get; set; }

        /// <summary>  
        /// 코멘트여부
        /// </summary> 
        public string CommentAt { get; set; }

        /// <summary>
        /// 정렬컬럼코드(01:등록일, 02:제목)
        /// </summary>
        public string OrderColumn { get; set; }

        /// <summary>
        /// 정렬형식(A:오름차순, D:내림차순)
        /// </summary>
        public string OrderType { get; set; }

        /// <summary>
        /// 검색 : 계량기 구분코드
        /// </summary>
        public string SearchBbsMrnrSeCode { get; set; }

        /// <summary>
        /// 메뉴코드
        /// </summary>
        public string menuCode { get; set; }

        
    }
}
