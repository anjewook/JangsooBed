using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.SystemMng
{
    /// <summary>  
    /// 권한그룹사용자이력 검색조건
    /// </summary> 
    public class AuthorGroupEmplyrHistSearchT : BaseSearchT
    {

        /// <summary>  
        /// 권한그룹사용자이력일련번호
        /// </summary> 
        public int SearchAuthorGroupEmplyrHistSn { get; set; }

        /// <summary>  
        /// 사원코드
        /// </summary> 
        public string SearchEmplCode { get; set; }

        /// <summary>  
        /// 사용자구분코드
        /// </summary> 
        public string SearchUserSeCode { get; set; }

        /// <summary>  
        /// 사용자ID
        /// </summary> 
        public string SearchUserId { get; set; }

        /// <summary>  
        /// 사용자명
        /// </summary> 
        public string SearchUserNm { get; set; }

        /// <summary>  
        /// 기관명
        /// </summary> 
        public string SearchInsttNm { get; set; }

        /// <summary>  
        /// 권한그룹코드
        /// </summary> 
        public string SearchAuthorGroupCode { get; set; }

        /// <summary>
        /// 권한상태코드
        /// </summary>
        public string SearchAuthorSttusCode { get; set; }

        /// <summary>  
        /// 처리일시
        /// </summary> 
        public DateTime SearchTreDt { get; set; }

    } 
}
