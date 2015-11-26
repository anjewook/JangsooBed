using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.Bbs
{
    public class BbscttCommentT : BaseModelT
    {
        /// <summary>
        /// 코멘트일련번호
        /// </summary>
        public long CommentSn { get; set; }

        /// <summary>  
        /// 게시글일련번호
        /// </summary> 
        public long BbscttSn { get; set; }

        /// <summary>  
        /// 코멘트내용
        /// </summary> 
        public string CommentCn { get; set; }

        /// <summary>  
        /// 삭제여부
        /// </summary> 
        public string DeleteAt { get; set; }

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
    }
}
