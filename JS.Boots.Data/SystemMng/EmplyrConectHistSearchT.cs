using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.SystemMng
{
    /// <summary>  
    /// 사용자접속이력 검색조건
    /// </summary> 
    public class EmplyrConectHistSearchT : BaseSearchT
    {
        /// <summary>  
        /// 사용자접속이력일련번호
        /// </summary> 
        public int SearchEmplyrConectHistSn { get; set; }

        /// <summary>  
        /// 사원코드
        /// </summary> 
        public string SearchEmplCode { get; set; }

        /// <summary>  
        /// 사용자ID
        /// </summary> 
        public string SearchUserId { get; set; }

        /// <summary>  
        /// 사용자명
        /// </summary> 
        public string SearchUserNm { get; set; }

        /// <summary>  
        /// 사용자구분코드
        /// </summary> 
        public string SearchUserSeCode { get; set; }

        /// <summary>  
        /// 소속명
        /// </summary> 
        public string SearchPsitnNm { get; set; }

        /// <summary>  
        /// 메뉴명
        /// </summary> 
        public string SearchMenuNm { get; set; }

        /// <summary>  
        /// 접속ip
        /// </summary> 
        public string SearchConectIp { get; set; }

        /// <summary>  
        /// 접속일시
        /// </summary> 
        public DateTime SearchConectDt { get; set; }

    } 

}
