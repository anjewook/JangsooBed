using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.SystemMng
{
    public class AuthorGroupEmplyrT
    {
        /// <summary>  
        /// 권한그룹코드
        /// </summary> 
        public string AuthorGroupCode { get; set; }

        /// <summary>  
        /// 사원코드
        /// </summary> 
        public string EmplCode { get; set; }

        /// <summary>
        /// 사용자ID
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 사용자명
        /// </summary>
        public string UserNm { get; set; }

        /// <summary>
        /// 부서코드
        /// </summary>
        public string DeptCode { get; set; }

        /// <summary>
        /// 부서명
        /// </summary>
        public string DeptNm { get; set; }

        /// <summary>  
        /// 전화번호
        /// </summary> 
        public string Telno { get; set; }

        /// <summary>  
        /// 휴대폰번호
        /// </summary> 
        public string Mbtlnum { get; set; }

    }
}
