using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.SystemMng
{
    /// <summary>  
    /// 권한그룹사용자이력
    /// </summary> 
    public class AuthorGroupEmplyrHistT : BaseModelT
    {
        /// <summary>  
        /// 권한그룹사용자이력일련번호
        /// </summary> 
        public long AuthorGroupEmplyrHistSn { get; set; }

        /// <summary>  
        /// 사원코드
        /// </summary> 
        public string EmplCode { get; set; }

        /// <summary>  
        /// 사용자구분코드
        /// </summary> 
        public string UserSeCode { get; set; }

        /// <summary>  
        /// 사용자구분코드명
        /// </summary> 
        public string UserSeCodeNm { get; set; }

        /// <summary>  
        /// 사용자ID
        /// </summary> 
        public string UserId { get; set; }

        /// <summary>  
        /// 사용자명
        /// </summary> 
        public string UserNm { get; set; }

        /// <summary>  
        /// 기관명
        /// </summary> 
        public string InsttNm { get; set; }

        /// <summary>  
        /// 권한그룹코드
        /// </summary> 
        public string AuthorGroupCode { get; set; }

        /// <summary>  
        /// 권한그룹코드명
        /// </summary> 
        public string AuthorGroupCodeNm { get; set; }

        /// <summary>
        /// 권한상태코드
        /// </summary>
        public string AuthorSttusCode { get; set; }

        /// <summary>
        /// 권한상태코드명
        /// </summary>
        public string AuthorSttusCodeNm { get; set; }

        /// <summary>  
        /// 처리일시
        /// </summary> 
        public DateTime TreDt { get; set; }

    }  
}
